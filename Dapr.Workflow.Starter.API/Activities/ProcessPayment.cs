using Dapr.Workflow.Starter.API.DataAccess;
using Dapr.Workflow.Starter.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Dapr.Workflow.Starter.API.Activities
{
    public class ProcessPayment : WorkflowActivity<PaymentUpdateWorkflowRequest, PaymentUpdateWorkFlowResponse>
    {
        private readonly ApplicationDBContext applicationDBContext;

        public ProcessPayment(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public override async Task<PaymentUpdateWorkFlowResponse> RunAsync(WorkflowActivityContext context, PaymentUpdateWorkflowRequest input)
        {
            var payment = await applicationDBContext.PaymentDetails.FirstOrDefaultAsync(x => x.Id == input.PaymentId);
            if (payment != null)
            {
                Thread.Sleep(7000);
                payment.PaymentStatus = "PaymentProcessed";
                payment.ReferenceNumber=Guid.NewGuid().ToString();
                await applicationDBContext.SaveChangesAsync();
                return new PaymentUpdateWorkFlowResponse() { IsSuccess = true };
            }
            return new PaymentUpdateWorkFlowResponse() { IsSuccess= false };
        }
    }
}
