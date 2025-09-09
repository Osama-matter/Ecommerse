using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerse.Model
{
    public class Cls_Product
    {




        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        public Cls_Catagoury Category { get; set; }
    }
}
