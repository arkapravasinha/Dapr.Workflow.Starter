namespace Dapr.Workflow.Starter.API.DTO
{
    public class CreateOrderWorkflowResponse
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public int PaymentId { get; set; }
    }
}
