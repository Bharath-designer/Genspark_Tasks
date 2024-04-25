
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class QuantityExceededException : Exception
    {
        public QuantityExceededException(string msg) : base(msg) { }
    }
    public class OrderBL : IOrderService
    {
        IRepository<int, List<Order>> _repository;

        public OrderBL(IRepository<int, List<Order>> repository)
        {
            _repository = repository;
        }
        public void AddOrdersToCustomer(int orderId, List<Order> orders)
        {
            if (_repository.GetById(orderId) == null)
                _repository.Add(orderId, orders);
            else
                throw new IdAlreadyFoundException("Cart with the given ID already found");
        }

        public void CreateOrder(int ordersId, Order order)
        {
            if (order.Product.Quantity > 5)
            {
                throw new QuantityExceededException("Quantity should not exceed 5");
            }
            double orderValue = order.TotalAmount;

            if (orderValue < 100)
            {
                orderValue += 100;
            }
            else if (order.Product.Quantity == 3 && orderValue >= 1500)
            {
                orderValue *= 0.95;
            }

            order.TotalAmount = orderValue;

            _repository.GetById(ordersId).Add(order);

        }

        public void DeleteOrder(int orderId)
        {
            _repository.Delete(orderId);
        }

        public List<List<Order>> GetAllOrders()
        {
            return _repository.GetAll();
        }

        public List<Order> GetOrderById(int orderId)
        {
            return _repository.GetById(orderId);
        }

        public void UpdateOrder(int orderId, List<Order> order)
        {
            _repository.Update(orderId, order);
        }

    }
}
