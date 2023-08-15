namespace E_CommerceFood.BLL.Dtos.OrderDtos
{
    public class OrderGetAllDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string UserName { get; set; }
    }
}
