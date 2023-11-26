using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dapr.Workflow.Starter.API.DataAccess.Models
{
    public class PaymentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public string ReferenceNumber { get; set; }

        public string PaymentStatus { get; set; }
    }
}
