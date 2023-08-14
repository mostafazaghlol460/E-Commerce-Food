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
            return _context.Orderss.Where(o=>o.IsDeleted==false).ToList();
        }

        public Orders GetById(int id)
        {
            return _context.Orderss
                            .FirstOrDefault(o => o.Id == id && o.IsDeleted == false);
        }

        public void Create(Orders orders)
        {
            _context.Orderss.Add(orders);
        }

        public void Update(Orders orders)
        {
            _context.Orderss.Update(orders);
        }

        public void Delete (int id)
        {
            Orders orderDb = GetById(id);
            orderDb.IsDeleted = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }




    }
}
