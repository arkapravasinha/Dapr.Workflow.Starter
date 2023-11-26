using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dapr.Workflow.Starter.API.DataAccess.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitCost { get; set; }

        public Inventory Inventory { get; set; }

        public List<Order> Orders { get; set; }
    }
}
