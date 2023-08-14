using E_CommerceFood.DAL.Model;

namespace E_CommerceFood.BLL.Dtos
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public User User { get; set; }

    }
}
