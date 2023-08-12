using E_CommerceFood.DAL.Model;

namespace E_CommerceFood.DAL.Repositories
{
    public interface IOrderRepository
    {
        List<Orders> GetAll();
        Orders GetById(int id);
        void Create(Orders orders);
        void Update(int id, Orders orders);
        void Delete(int id);
        void Save();
    }
}
