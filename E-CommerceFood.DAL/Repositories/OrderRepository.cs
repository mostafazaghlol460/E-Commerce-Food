using E_CommerceFood.DAL.Model;

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
            return _context.Orderss.ToList();
        }

        public Orders GetById(int id)
        {
            return _context.Orderss
                            .FirstOrDefault(o => o.Id == id);
        }

        public void Create(Orders orders)
        {
            _context.Orderss.Add(orders);
        }

        public void Update(int id,Orders orders)
        {
            Orders orderDb = GetById(id);

            orderDb.Total = orders.Total;
            orderDb.Quantity = orders.Quantity;
            orderDb.UserId = orders.UserId;
            orderDb.Date = orders.Date;
        }

        public void Delete (int id)
        {
            Orders orderDb = GetById(id);
            _context.Orderss.Remove(orderDb);
        }

        public void Save()
        {
            _context.SaveChanges();
        }




    }
}
