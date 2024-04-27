using ShoppingModelLibrary;

namespace ShoppingModelLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CartId { get; set; }
        public int OrdersId { get; set; }

        public Customer(int id, string name, int cartId, int ordersId)
        {
            Id = id;
            Name = name;
            CartId = cartId;
            OrdersId = ordersId;
        }
    }
}
