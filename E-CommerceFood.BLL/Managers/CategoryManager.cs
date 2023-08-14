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

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            
        }
        public List<CategoryGetAll> GetAll()
        {
            List<Category> categories = categoryRepository.GetAll();
            List<CategoryGetAll> categoryGetAlls = new List<CategoryGetAll>();

            foreach (Category category in categories)
            {
                var categorylist = new CategoryGetAll()
                {
                    Id = category.Id,
                    Name = category.Name,
                 
                };
                categoryGetAlls.Add(categorylist);

            }
            return categoryGetAlls;
        }
        public CategoryDetailsDto GetById(int id)
        {
            Category category = categoryRepository.GetById(id);
            var categoryDto = new CategoryDetailsDto
            {
                Name = category.Name
            };

            return categoryDto;
        }
        public CategoryAddDto create(CategoryAddDto categoryCreateDto)
        {
            //if (categoryCreateDto == null)
            //    return null;

            var categorydb = new Category()
            {
                Name = categoryCreateDto.Name,
            };
            categoryRepository.Add(categorydb);
            categoryRepository.Save();

            var result = new CategoryAddDto()
            {
                Name = categorydb.Name
            };
            return result;

        }
        public Category Delete(int id)
        {
            var data = categoryRepository.GetById(id);

            if (data != null)
            {

                categoryRepository.Delete(id);
                return data;
            }


            return null;
        }
        public CateoryUpdateDto Update(CateoryUpdateDto categoryUpdateDto, int id)
        {
            //if (productUpdateDto == null)
            //    return null;
            var categorydb = categoryRepository.GetById(id);

            categorydb.Name = categoryUpdateDto.Name;
            categoryRepository.Update(categorydb, id);


            return categoryUpdateDto;


        }
    }
}
