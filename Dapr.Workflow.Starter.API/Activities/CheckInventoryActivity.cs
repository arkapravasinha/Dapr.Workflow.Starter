using Dapr.Workflow.Starter.API.DataAccess;
using Dapr.Workflow.Starter.API.DataAccess.Models;
using Dapr.Workflow.Starter.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Dapr.Workflow.Starter.API.Activities
{
    public class CheckInventoryActivity : WorkflowActivity<InventoryUpdateWorkflowRequest, InventoryUpdateWorkflowResponse>
    {
        ApplicationDBContext applicationDBContext;
        public CheckInventoryActivity(ApplicationDBContext applicationDBContext) => this.applicationDBContext = applicationDBContext;
        public override async Task<InventoryUpdateWorkflowResponse> RunAsync(WorkflowActivityContext context, InventoryUpdateWorkflowRequest input)
        {
            int currentStock = 0;
            Inventory inventory = null;
            if(input != null)
            {
                inventory = await applicationDBContext.Inventories?.FirstOrDefaultAsync(x => x.ProductId == input.ProductId);
                currentStock = inventory?.stock ?? 0;
            }
            return new InventoryUpdateWorkflowResponse() { IsSuccess = currentStock>input.ProductQty, ProductName=inventory?.Product?.ProductName };
        }
    }
}
