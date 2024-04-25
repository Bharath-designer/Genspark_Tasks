
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class QuantityExceededException: Exception
    {
        public QuantityExceededException(string msg): base(msg) { }
    }
    public class OrderBL: IOrderService
    {
        IRepository<int, Order> _repository;

        public OrderBL(IRepository<int, Order> repository)
        {
            _repository = repository;
        }

        public void AddOrder(int id, Order order)
        {
            foreach (OrderedProduct product in order.Products)
            {
                if (product.Quantity > 5)
                {
                    throw new QuantityExceededException("Quantity should not exceed 5");
                }
            }
            double orderValue = CalculateOrderValue(order);

            if (orderValue < 100)
            {
                orderValue += 100;
            }
            else if (order.Products.Count == 3 && orderValue >= 1500)
            {
                orderValue *= 0.95;
            }

            order.TotalAmount = orderValue;

            _repository.Add(id, order);

        }

        private static double CalculateOrderValue(Order order)
        {
            double orderValue = 0;
            foreach (var product in order.Products)
            {
                orderValue += product.TotalAmount;
            }
            return orderValue;
        }


        public void DeleteOrder(int orderId)
        {
            _repository.Delete(orderId);
        }

        public List<Order> GetAllOrders()
        {
            return _repository.GetAll();
        }

        public Order GetOrderById(int orderId)
        {
            return _repository.GetById(orderId);
        }

        public void UpdateOrder(int orderId, Order order)
        {
            _repository.Update(orderId, order);
        }

    }
}
