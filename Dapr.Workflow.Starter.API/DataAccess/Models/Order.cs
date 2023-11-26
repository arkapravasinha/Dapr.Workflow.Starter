using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dapr.Workflow.Starter.API.DTO;

namespace Dapr.Workflow.Starter.API.DataAccess.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public Product Product{ get; set; }
        
        public int Qty { get; set; }
        public double Total { get; set; }
        public double Actual_Cost { get; set; }
        public double Tax { get; set; }

        [ForeignKey("PaymentId")]
        public PaymentDetails PaymentDetails { get; set; }

        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public string Status { get; set; }
    }
}
