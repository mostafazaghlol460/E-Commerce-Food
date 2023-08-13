using E_CommerceFood.BLL.Dtos;
using E_CommerceFood.BLL.Managers.OrderManagerModules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrderManager orderManager;
        public OrdersController(OrderManager orderManager)
        {
            this.orderManager = orderManager;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderGetAllDto> orders = orderManager.GetAll();

            if (orders.Count > 0)
            {
                return Ok(orders);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public IActionResult Create(OrderCreatedDto orderCreatedDto)
        {
            if (ModelState.IsValid)
            {
                var order = orderManager.Create(orderCreatedDto);

                return Created("api/Orders/" + order.Id, order);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
