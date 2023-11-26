using Dapr.Workflow.Starter.API.Activities;
using Dapr.Workflow.Starter.API.DTO;
using DurableTask.Core.Exceptions;

namespace Dapr.Workflow.Starter.API.Workflows
{
    public class CreateOrderFlow : Workflow<CreateOrderRequest, CreateOrderResponse>
    {
        public override async Task<CreateOrderResponse> RunAsync(WorkflowContext context, CreateOrderRequest input)
        {

            var orderId = new Guid(context.InstanceId);
            context.SetCustomStatus("CheckingInventory");
            //Check Inventory
            InventoryUpdateWorkflowResponse inventoryCheckresult= await context.CallActivityAsync<InventoryUpdateWorkflowResponse>(nameof(CheckInventoryActivity), new InventoryUpdateWorkflowRequest()
            {
                ProductId=input.ProductId,
                ProductQty=input.ProductQuantity
            });

            if(!inventoryCheckresult.IsSuccess ) {
                context.SetCustomStatus("NoInventoryFound");
                await context.CallActivityAsync(nameof(SendNotificationActivity), new NotificationSentWorkflowRequest()
                {
                    UsertId=input.UserId,
                    Message=$"Invenotry is not found for your Product {inventoryCheckresult.ProductName}"
                });
                return new CreateOrderResponse() { IsSuccess = false,Error= "NoInventoryFound" };
            }
            //Hold Inventory
            context.SetCustomStatus("HoldingInventory");
            InventoryUpdateWorkflowResponse inventoryHoldResult;
            try
            {
                inventoryHoldResult = await context.CallActivityAsync<InventoryUpdateWorkflowResponse>(nameof(HoldInventoryActivity), new InventoryUpdateWorkflowRequest()
                {
                    ProductId = input.ProductId,
                    ProductQty = input.ProductQuantity
                });
            }
            catch (TaskFailedException ex)
            {
                context.SetCustomStatus("InventoryHoldFailed");
                await context.CallActivityAsync(nameof(SendNotificationActivity), new NotificationSentWorkflowRequest()
                {
                    UsertId = input.UserId,
                    Message = $"Uanble update stocks for your Product {inventoryCheckresult.ProductName}"
                });
                return new CreateOrderResponse() { IsSuccess = false, Error = "InventoryHoldFailed" };
            }

            
            if(!inventoryCheckresult.IsSuccess )
            {
                context.SetCustomStatus("UnableToHoldInventory");
                await context.CallActivityAsync(nameof(SendNotificationActivity), new NotificationSentWorkflowRequest()
                {
                    UsertId = input.UserId,
                    Message = $"Uanble to find stocks for your Product {inventoryCheckresult.ProductName}"
                });
                return new CreateOrderResponse() { IsSuccess = false, Error = "UnableToHoldInventory" };
            }
            context.SetCustomStatus("CreatingOrder");
            CreateOrderWorkflowResponse createOrderWorkflowResult;
            //Create Order
            try
            {
                createOrderWorkflowResult = await context.CallActivityAsync<CreateOrderWorkflowResponse>(nameof(CreateOrderActivity), new CreateOrderWorkflowRequest()
                {
                    CardHolderName = input.CardHolderName,
                    CardNumber = input.CardNumber,
                    OrderId = orderId,
                    OrderStatus = "Created",
                    ProductId = input.ProductId,
                    ProductQuantity = input.ProductQuantity,
                    UserId = input.UserId
                });
            }
            catch (TaskFailedException ex)
            {
                context.SetCustomStatus("UnableToCreateOrder");
                await context.CallActivityAsync(nameof(SendNotificationActivity), new NotificationSentWorkflowRequest()
                {
                    UsertId = input.UserId,
                    Message = $"Uanble to find stocks for your Product {inventoryCheckresult.ProductName}"
                });
                await context.CallActivityAsync(nameof(ReleaseInventoryActivity), new InventoryUpdateWorkflowRequest()
                {
                    ProductId = input.ProductId,
                    ProductQty = input.ProductQuantity
                });
                return new CreateOrderResponse() { IsSuccess = false, Error = "UnableToCreateOrder" };
            }
            context.SetCustomStatus("OrderCreated");
            context.SetCustomStatus("StartingPayment");

            //Process Payment
            PaymentUpdateWorkFlowResponse paymentUpdateWorkFlowResponse = await context.CallActivityAsync<PaymentUpdateWorkFlowResponse>(nameof(ProcessPayment), new PaymentUpdateWorkflowRequest()
            {
                PaymentId = createOrderWorkflowResult.PaymentId

            });

            if(!paymentUpdateWorkFlowResponse.IsSuccess)
            {
                context.SetCustomStatus("PaymentFailed");
                await context.CallActivityAsync(nameof(SendNotificationActivity), new NotificationSentWorkflowRequest()
                {
                    UsertId = input.UserId,
                    Message = $"Uanble to verify Payment, Please retry"
                });
            }

            //Update Order
            context.SetCustomStatus("PaymentSuccessfull");
            var results = await context.CallActivityAsync<bool>(nameof(UpdateOrderActivity), new UpdateOrderWorkflowRequest()
            {
                OrderId = orderId,
                Status="PaymentSuccessfull"
            });

            //sent Confirmation 
            await context.CallActivityAsync(nameof(SendNotificationActivity), new NotificationSentWorkflowRequest()
            {
                UsertId = input.UserId,
                Message = "Payment is successfull and order is confirmed"
            });

            //Update Order
            context.SetCustomStatus("OrderConfirmed");
            await context.CallActivityAsync<bool>(nameof(UpdateOrderActivity), new UpdateOrderWorkflowRequest()
            {
                OrderId = orderId,
                Status = "OrderConfirmed"
            });


            return new CreateOrderResponse() { IsSuccess = true };

        }
    }
}
