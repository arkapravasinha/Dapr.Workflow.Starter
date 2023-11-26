using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dapr.Workflow.Starter.API.DataAccess.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductId { get; set; }
        public int stock { get; set; }
        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
