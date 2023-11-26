namespace Dapr.Workflow.Starter.API.DTO
{
    public class UpdateOrderWorkflowRequest
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
    }
}
