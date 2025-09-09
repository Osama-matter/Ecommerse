using Ecommerse.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerse.ViewModel
{
    public class ProductCreatrDTOs
    {

        public int ID { get; set; }

        public string Name { get; set; }


        [Column(TypeName = "decimal(10.2)")]
        public decimal Price { get; set; }

        public int   catagouryID { get; set; }
    }
}
