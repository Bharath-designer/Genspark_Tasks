using ShoppingModelLibrary;

namespace ShoppingModelLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Cart Cart { get; set; }

        public List<Order> Orders { get; set; }

        public Customer(int id, string name, Cart cart, List<Order> orders)
        {
            Id = id;
            Name = name;
            Cart = cart;
            Orders = orders;
        }
    }
}
