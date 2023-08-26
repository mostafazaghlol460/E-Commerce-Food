using E_CommerceFood.BLL.Dtos.LookUpDtos;
using E_CommerceFood.BLL.Dtos.UserDtos;
using E_CommerceFood.DAL.Model;

namespace E_CommerceFood.BLL.Dtos.OrderDtos
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string? UserId { get; set; }

    }
}
