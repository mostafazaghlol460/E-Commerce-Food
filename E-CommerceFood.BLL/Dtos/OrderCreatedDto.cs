using E_CommerceFood.DAL.Model;

namespace E_CommerceFood.BLL.Dtos
{
    public class OrderCreatedDto
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
