using E_CommerceFood.DAL.Repositories;
using E_CommerceFood.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_CommerceFood.BLL.Dtos;
using E_CommerceFood.DAL.Model;

namespace E_CommerceFood.BLL.Managers
{
   public class CategoryManager
    {
        ICategoryRepository categoryRepository;
        DBContextFood context;

        public CategoryManager(ICategoryRepository categoryRepository, DBContextFood context)
        {
            this.categoryRepository = categoryRepository;
            this.context = context;
        }
        //public List<CategoryGetAll> GetAll()
        //{
        //    List<Category> categories = categoryRepository.GetAll();
        //    List<Category> CategoryGetAlls = new List<CategoryGetAll>();

        //    foreach (Product product in products)
        //    {
        //        var productlist = new ProductGetAll
        //        {
        //            Id = product.Id,
        //            Name = product.Name,
        //            Description = product.Descrption,
        //            Image = product.Image,
        //            CategoryId = product.CategoryId
        //        };
        //        productGetAlls.Add(productlist);

        //    }
        //    return productGetAlls;
        //}
    }
}
