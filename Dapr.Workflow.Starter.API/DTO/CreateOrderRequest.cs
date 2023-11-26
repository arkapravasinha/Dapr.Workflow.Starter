using System.ComponentModel.DataAnnotations;

namespace Dapr.Workflow.Starter.API.DTO
{
    public class CreateOrderRequest
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int UserId { get; set; }
        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }
    }
}
