using E_CommerceFood.BLL.Dtos;
using E_CommerceFood.BLL.Managers.OrderManagerModules;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderManager _orderManager;
        public OrdersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderManager.GetAll());
        }

        [HttpGet]
        [Route("Details/{id}")]

        public IActionResult GetById(int id)
        {
            var order = _orderManager.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create(OrderCreatedDto orderCreatedDto)
        {
            if (ModelState.IsValid ==true)
            {
                var order = _orderManager.Create(orderCreatedDto);

                return Created("api/Orders/" + order.Id, order);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Put (OrderUpdateDto orderUpdateDto,int id)
        {
           if(orderUpdateDto != null)
            {
                var result = _orderManager.Update(orderUpdateDto, id);

                if (result !=null) 
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
          var result= _orderManager.Delete(id);

            if (result != null) return Ok();
            return NotFound();
        }

    }
}
