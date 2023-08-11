using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; } 
        public double Total { get; set; }
        [ForeignKey(nameof(user))]
        public int ? UserId { get; set; }
        public virtual User ? user { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
