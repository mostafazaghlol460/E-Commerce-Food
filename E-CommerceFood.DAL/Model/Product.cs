using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public string Image{ get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(category))]
        public int? CategoryId { get; set; }
        public virtual Category? category { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }


    }
}
