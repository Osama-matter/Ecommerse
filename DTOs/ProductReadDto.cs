namespace Ecommerse.DTOs
{
    public class ProductReadDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryReadDto Category { get; set; }

    }
}
