
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IOrderService
    {
        void AddOrder(int id, Order order);
        void UpdateOrder(int orderId, Order order);
        Order GetOrderById(int orderId);
        List<Order> GetAllOrders();
        void DeleteOrder(int orderId);
    }

}
