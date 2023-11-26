namespace Dapr.Workflow.Starter.API.DTO
{
    public class CreateOrderResponse
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public int PaymentId { get; set; }
    }
}
