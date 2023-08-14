using E_CommerceFood.DAL.Model;

namespace E_CommerceFood.DAL.Repositories
{
    public interface IOrderRepository
    {
        List<Orders> GetAll();
        Orders GetById(int id);
        void Create(Orders orders);
        void Update(Orders orders, int id);
        void Delete(int id);
        void Save();
    }
}
