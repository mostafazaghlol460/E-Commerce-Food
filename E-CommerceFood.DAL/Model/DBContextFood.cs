using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceFood.DAL.Model
{
    public class DBContextFood:IdentityDbContext<ApplicationUser>
    {
        public DBContextFood(DbContextOptions<DBContextFood> options):base(options)
        {
            
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Orders> Orderss { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
