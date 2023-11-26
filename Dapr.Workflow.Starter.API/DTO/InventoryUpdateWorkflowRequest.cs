namespace Dapr.Workflow.Starter.API.DTO
{
    public class InventoryUpdateWorkflowRequest
    {
        public int ProductId { get; set; }
        public int ProductQty { get; set; }
    }
}
