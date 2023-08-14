using E_CommerceFood.BLL.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using E_CommerceFood.BLL.Dtos;

namespace E_CommerceFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        ProductManager productManager;
        public  ProductController(ProductManager productManager )
        {
            this.productManager = productManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductGetAll> product = productManager.GetAll();

            if (product.Count > 0)
            {
                return Ok(product);
            }
            else { return NotFound(); };
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = productManager.GetById(id);
            if (product == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(product);    
            }

        }
        [HttpPost]
        public IActionResult create(ProductCreateDto productCreateDto)
        {
            if(ModelState.IsValid)
            {
                var product = productManager.create(productCreateDto);
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = productManager.Delete(id);
            if (result != null) return Ok();
            return NotFound();

        }
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult Update (ProductUpdateDto productUpdateDto, int id)
        {
            if(productUpdateDto != null)
            {
                var result = productManager.Update(productUpdateDto, id);
                 return Ok(result);
               
            }
            return NotFound();
        }
        
        
    }
}
