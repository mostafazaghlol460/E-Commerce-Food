using E_CommerceFood.BLL.Dtos;
using E_CommerceFood.DAL;
using E_CommerceFood.DAL.Model;
using E_CommerceFood.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceFood.BLL.Managers.OrderManagerModules
{
    public class OrderManager
    {
        IOrderRepository orderRepository;
        DBContextFood context;
        public OrderManager(IOrderRepository orderRepository,
                            DBContextFood context)
        {
            this.orderRepository = orderRepository;
            this.context = context;
        }

        public List<OrderGetAllDto> GetAll()
        {
            List<Orders> orders = orderRepository.GetAll();
            List<OrderGetAllDto> orderGetAllDtos = new List<OrderGetAllDto>();

            if(orders != null)
            {
                foreach (Orders order in orders)
                {
                    var orderList = new OrderGetAllDto
                    {
                        Id = order.Id,
                        Date = order.Date,
                        Quantity = order.Quantity,
                        Total = order.Total,
                        UserName = order?.user?.UserName
                    };
                    orderGetAllDtos.Add(orderList);
                }
            }
            
            return orderGetAllDtos;
        }

        public OrderDetailsDto GetById(int id)
        {
            Orders order = orderRepository.GetById(id);
            var orderDto = new OrderDetailsDto
            {
                Id = order.Id,
                Date = order.Date,
                Quantity = order.Quantity,
                Total = order.Total,
                UserId = order.UserId
            };
            return orderDto;
        }
        public OrderAddedDto Create(OrderCreatedDto orderCreatedDto)
        {
            if (orderCreatedDto == null)
                throw new ArgumentException(nameof(orderCreatedDto));

            var orderDb = new Orders()
            {
                Date = orderCreatedDto.Date,
                Quantity = orderCreatedDto.Quantity,
                Total = orderCreatedDto.Total,
                UserId=orderCreatedDto.UserId
            };

            orderRepository.Create(orderDb);
            orderRepository.Save();

            var result = new OrderAddedDto()
            {
                Id = orderDb.Id,
                Quantity = orderDb.Quantity
            };
            return result;

        }

        public OrderUpdateDto Update(OrderUpdateDto orderUpdateDto, int id)
        {
            if (orderUpdateDto == null)
                return null;

            var orderDb = orderRepository.GetById(id);

            if (orderDb == null)
                return null;

            orderDb.Date = orderUpdateDto.Date;
            orderDb.Quantity = orderUpdateDto.Quantity;
            orderDb.Total = orderUpdateDto.Total;
            orderDb.UserId = orderUpdateDto.UserId;

            orderRepository.Update(orderDb, id);

            return orderUpdateDto;
        }
       

    }
}
