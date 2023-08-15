namespace E_CommerceFood.BLL.Dtos.ProductDtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
    }
}
