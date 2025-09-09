using Ecommerse.Model;
using Ecommerse.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerse.Interface
{
    public interface IProduct
    {

        public List<Cls_Product> ShowAll(); 
        
        public Cls_Product GetUingID(int id);  

        public  void  Edit (Cls_Product model);

        public bool  Delete (int ID);

        public void  Add(Cls_Product model);   

        public void Save (); 

    }
}
