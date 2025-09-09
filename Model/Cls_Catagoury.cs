namespace Ecommerse.Model
{
    public class Cls_Catagoury
    {
        public int ID { get; set; }

        public string  Name  { get; set; }

        public ICollection<Cls_Product> products { get; set; } 


    }
}
