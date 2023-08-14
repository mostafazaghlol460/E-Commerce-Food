using E_CommerceFood.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceFood.DAL.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        DBContextFood _context;
        public OrderRepository(DBContextFood context)
        {
            _context = context;
        }

        public List<Orders> GetAll()
        {
            return _context.Orderss.Where(o=>o.IsDeleted==false).Include(u=>u.user).ToList();
        }

        public Orders GetById(int id)
        {
            return _context.Orderss
                            .FirstOrDefault(o => o.Id == id && o.IsDeleted == false);
        }

        public void Create(Orders orders)
        {
            _context.Orderss.Add(orders);
            Save();
        }

        public void Update(Orders orders,int id)
        {
            var orderDb = _context.Orderss.FirstOrDefault(o => o.Id == id);
            _context.Orderss.Update(orders);
            Save();
        }

        public void Delete (int id)
        {
            Orders orderDb = GetById(id);
            orderDb.IsDeleted = true;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }




    }
}
