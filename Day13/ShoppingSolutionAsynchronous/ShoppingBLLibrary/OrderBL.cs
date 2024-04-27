
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
        public async Task AddOrdersToCustomer(int orderId, List<Order> orders)
        {
            if ((await _repository.GetById(orderId)) == null)
                _repository.Add(orderId, orders);
            else
                throw new IdAlreadyFoundException("Cart with the given ID already found");
        }

        public async Task CreateOrder(int ordersId, Order order)
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
            else if (order.Product.Quantity >= 3 && orderValue >= 1500)
            {
                orderValue *= 0.95;
            }

            order.TotalAmount = orderValue;

            (await _repository.GetById(ordersId)).Add(order);

        }

        public void DeleteOrder(int orderId)
        {
            _repository.Delete(orderId);
        }

        public async Task<List<List<Order>>> GetAllOrders()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Order>> GetOrderById(int orderId)
        {
            return await _repository.GetById(orderId);
        }

        public void UpdateOrder(int orderId, List<Order> order)
        {
            _repository.Update(orderId, order);
        }

    }
}
