using E_CommerceFood.BLL.Dtos.CategoryDtos;
using E_CommerceFood.BLL.Managers.CategoryModules;
using E_CommerceFood.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryManager categoryManager;
        public CategoryController(CategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CategoryGetAll> category = categoryManager.GetAll();

            if (category.Count > 0)
            {
                return Ok(category);
            }
            else { return NotFound(); };
        }
        [HttpGet]
        [Route("Detail/{id}")]

        public IActionResult GetById(int id)
        {
            var category = categoryManager.GetById(id);
            if (category == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPost]
        public IActionResult Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var category = categoryManager.create(categoryAddDto);
                if (category != null)
                {
                    return Ok(category);
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete/{id}")]

        public IActionResult Delete(int id)
        {
            var result = categoryManager.Delete(id);
            if (result != null) return Ok();
            return NotFound();

        }
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update(CateoryUpdateDto cateoryUpdateDto, int id)
        {
            if (cateoryUpdateDto != null)
            {
                var result = categoryManager.Update(cateoryUpdateDto, id);
                return Ok(result);

            }
            return NotFound();
        }
    




    }
}
