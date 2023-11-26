namespace Dapr.Workflow.Starter.API.DTO
{
    public class CreateOrderWorkflowRequest
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int UserId { get; set; }
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }
    }
}
