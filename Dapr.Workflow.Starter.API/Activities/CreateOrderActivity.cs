using Dapr.Workflow.Starter.API.DataAccess;
using Dapr.Workflow.Starter.API.DataAccess.Models;
using Dapr.Workflow.Starter.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Dapr.Workflow.Starter.API.Activities
{
    public class CreateOrderActivity : WorkflowActivity<CreateOrderWorkflowRequest, CreateOrderWorkflowResponse>
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CreateOrderActivity(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public override async Task<CreateOrderWorkflowResponse> RunAsync(WorkflowActivityContext context, CreateOrderWorkflowRequest input)
        {
            var product=await applicationDBContext.Products.FirstOrDefaultAsync(x=>x.Id==input.ProductId);
            if (product != null) {
                Order order = new Order()
                {
                    Id = input.OrderId,
                    UserId = input.UserId,
                    Status = input.OrderStatus,
                    ProductId = input.ProductId,
                    Qty = input.ProductQuantity,
                    Actual_Cost = product.UnitCost * input.ProductQuantity,
                    Tax = product.UnitCost * input.ProductQuantity * 0.18,
                    PaymentDetails= new PaymentDetails() { CardHolderName=input.CardHolderName,CardNumber=input.CardNumber,ReferenceNumber=string.Empty,PaymentStatus=string.Empty}
                };
                await applicationDBContext.Orders.AddAsync(order);

                await applicationDBContext.SaveChangesAsync();
                return new CreateOrderWorkflowResponse() { IsSuccess = true ,PaymentId=order.PaymentDetails.Id};
            }
            return new CreateOrderWorkflowResponse() { IsSuccess = false };
        }
    }
}
