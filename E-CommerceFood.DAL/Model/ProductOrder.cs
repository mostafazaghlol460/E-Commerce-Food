using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Model
{
    //[PrimaryKey(nameof(OrderId),nameof(ProductId))]
    public class ProductOrder
    {
        [ForeignKey(nameof(orders))]

        public int ?OrderId { get; set; }
        [ForeignKey(nameof(product))]

        public int ?ProductId { get; set;}
        public virtual Product ? product { get; set; }
        public virtual Orders ?orders { get; set; }


    }
}
