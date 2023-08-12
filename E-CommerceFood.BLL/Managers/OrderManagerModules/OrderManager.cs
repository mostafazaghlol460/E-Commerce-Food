using E_CommerceFood.DAL.Repositories;

namespace E_CommerceFood.BLL.Managers.OrderManagerModules
{
    public class OrderManager
    {
        private OrderRepository _orderRepo;

        public OrderManager(OrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

    }
}
