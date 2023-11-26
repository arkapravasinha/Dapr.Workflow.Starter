﻿using Dapr.Workflow.Starter.API.DataAccess;
using Dapr.Workflow.Starter.API.DataAccess.Models;
using Dapr.Workflow.Starter.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace Dapr.Workflow.Starter.API.Activities
{
    public class HoldInventoryActivity : WorkflowActivity<InventoryUpdateWorkflowRequest, InventoryUpdateWorkflowResponse>
    {
        private readonly ApplicationDBContext applicationDBContext;

        public HoldInventoryActivity(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public override async Task<InventoryUpdateWorkflowResponse> RunAsync(WorkflowActivityContext context, InventoryUpdateWorkflowRequest input)
        {
            var inventory=await applicationDBContext.Inventories.FirstOrDefaultAsync(x=>x.ProductId==input.ProductId);
            if (inventory !=null && inventory.stock>input.ProductQty)
            {
                inventory.stock -= input.ProductQty;
                await applicationDBContext.SaveChangesAsync();
                return new InventoryUpdateWorkflowResponse()
                {
                    IsSuccess = true,
                    ProductName = inventory?.Product?.ProductName
                };
            }
            return new InventoryUpdateWorkflowResponse()
            {
                IsSuccess = true,
                ProductName = inventory?.Product?.ProductName
            };
        }
    }
}
