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

            if (orders !=null)
            {
                return Ok(orders);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = orderManager.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
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

        [HttpPut]

        [Route("Update/{id}")]

        public IActionResult Put (OrderUpdateDto orderUpdateDto,int id)
        {
           if(orderUpdateDto != null)
            {
                var result = orderManager.Update(orderUpdateDto, orderUpdateDto.Id);

                if (result !=null) 
                {
                    return Ok(result);
                }
            }
            return BadRequest();

        }



    }
}
