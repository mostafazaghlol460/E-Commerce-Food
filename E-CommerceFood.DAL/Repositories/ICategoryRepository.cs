using E_CommerceFood.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category Add(Category category);
         void Save();
     
         void Update(Category category, int id);
         void Delete(int id);
    }
}
