namespace E_CommerceFood.BLL.Dtos.OrderDtos
{
    public class OrderUpdateDto
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string? UserId { get; set; }

    }
}
