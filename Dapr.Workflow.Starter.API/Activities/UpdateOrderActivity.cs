using Dapr.Workflow.Starter.API.DataAccess;
using Dapr.Workflow.Starter.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Dapr.Workflow.Starter.API.Activities
{
    public class UpdateOrderActivity : WorkflowActivity<UpdateOrderWorkflowRequest, bool>
    {
        private readonly ApplicationDBContext applicationDBContext;

        public UpdateOrderActivity(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public override async Task<bool> RunAsync(WorkflowActivityContext context, UpdateOrderWorkflowRequest input)
        {
            var order=await applicationDBContext.Orders.FirstOrDefaultAsync(x=>x.Id==input.OrderId); 
            if(order != null)
                order.Status = input.Status;
            await applicationDBContext.SaveChangesAsync();
            return true;
        }
    }
}
