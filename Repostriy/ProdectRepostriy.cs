using Ecommerse.DbContect;
using Ecommerse.Interface;
using Ecommerse.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse.Repostriy
{
    public class ProdectRepostriy : IProduct
    {
        private readonly EcommesdbContext dbContext;

        public ProdectRepostriy(EcommesdbContext context)
        {
            dbContext = context;
        }

        public void Add(Cls_Product model) => dbContext.products.Add(model);

        public bool Delete(int ID)
        {
            var product = GetUingID(ID);
            if (product != null)
            {
                dbContext.products.Remove(product);
                return true;
            }
            return false;
        }

        public void Edit(Cls_Product model) => dbContext.products.Update(model);

        public Cls_Product GetUingID(int id) =>
            dbContext.products.Include(p => p.Category).FirstOrDefault(p => p.ID == id);

        public List<Cls_Product> ShowAll() =>
            dbContext.products.Include(p => p.Category).ToList();

        public void Save() => dbContext.SaveChanges();
    }
}
