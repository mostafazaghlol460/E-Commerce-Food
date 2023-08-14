using E_CommerceFood.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        DBContextFood _context;
        public CategoryRepository(DBContextFood context)
        {
            _context = context;

        }
        public Category GetById(int id)
        {
            return _context.Categories.SingleOrDefault(p => p.Id == id && p.IsDeleted == false);
        }
        public List<Category> GetAll()
        {
            return _context.Categories.Where(p => p.IsDeleted == false).ToList();
        }
        public Category Add(Category category)
        {
            Category cat = new Category()
            {
                Name = category.Name,
              
            };
            _context.Categories.Add(cat);
            return cat;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Category category = GetById(id);
            category.IsDeleted = true;
            Save();
        }
        public void Update(Category category, int id)
        {
            var categorydb = _context.Categories.FirstOrDefault(g => g.Id == id);
            _context.Categories.Update(categorydb);
            Save();
        }

        






    }
}