
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IOrderService
    {
        Task AddOrdersToCustomer(int orderId, List<Order> orders);
        Task CreateOrder(int id, Order order);
        void UpdateOrder(int orderId, List<Order> order);
        Task<List<Order>> GetOrderById(int orderId);
        Task<List<List<Order>>> GetAllOrders();
        void DeleteOrder(int orderId);
    }

}
