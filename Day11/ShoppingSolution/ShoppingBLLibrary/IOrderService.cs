
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IOrderService
    {
        void AddOrdersToCustomer(int orderId, List<Order> orders);
        void CreateOrder(int id, Order order);
        void UpdateOrder(int orderId, List<Order> order);
        List<Order> GetOrderById(int orderId);
        List<List<Order>> GetAllOrders();
        void DeleteOrder(int orderId);
    }

}
