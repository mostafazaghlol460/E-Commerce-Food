using E_CommerceFood.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        DBContextFood _context;
        public ProductRepository(DBContextFood context)
        {
            _context = context;

        }
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id && p.IsDeleted==false);
        }
        public List<Product> GetAll()
        {
            return _context.Products.Where(p=> p.IsDeleted==false).ToList();
        }
        public Product Add(Product product)
        {
            Product prod = new Product()
            {
                Name = product.Name,
                Descrption = product.Descrption,
                Image = product.Image,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
             _context.Products.Add(prod);
                return prod;
        }
       
        public void Save()
        {
            _context.SaveChanges();
        }
       

        public void Delete(int id)
        {
            Product product = GetById(id);
            product.IsDeleted = true;
            Save();
        }
        public void Update(Product product , int id )
        {
            var productdb = _context.Products.FirstOrDefault(product=>product.Id == id);
            _context.Products.Update(productdb);
            Save();
        }
        public List<Product> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsStartingWith(string searchTerm)
        {
            throw new NotImplementedException();
        }

       

    }
}
