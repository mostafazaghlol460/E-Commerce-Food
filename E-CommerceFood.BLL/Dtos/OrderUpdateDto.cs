﻿namespace E_CommerceFood.BLL.Dtos
{
    public class OrderUpdateDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public string? UserId { get; set; }
    }
}