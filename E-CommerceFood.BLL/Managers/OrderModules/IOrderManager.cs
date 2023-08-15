using E_CommerceFood.BLL.Dtos.OrderDtos;
using E_CommerceFood.DAL.Model;

namespace E_CommerceFood.BLL.Managers.OrderManagerModules
{
    public interface IOrderManager
    {
        List<OrderGetAllDto> GetAll();
        OrderDetailsDto GetById(int id);
        OrderAddedDto Create(OrderCreatedDto orderCreatedDto);
        OrderUpdateDto Update(OrderUpdateDto orderUpdateDto, int id);
        Orders Delete(int id);
    }
}
