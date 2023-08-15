using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.BLL.Dtos.ProductDtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
    }
}
