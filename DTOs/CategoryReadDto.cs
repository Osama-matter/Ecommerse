using Ecommerse.Model;

namespace Ecommerse.DTOs
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Cls_Product product { get; set; }
    }
}
