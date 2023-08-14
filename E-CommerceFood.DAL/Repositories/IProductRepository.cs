using E_CommerceFood.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Add(Product product);
        void Save();
        Product GetById(int id);
        List<Product> GetProductByName(string name);
        List<Product> GetProductsStartingWith(string searchTerm);
        void Update(Product product, int id);
        void Delete(int id);
    }
}
