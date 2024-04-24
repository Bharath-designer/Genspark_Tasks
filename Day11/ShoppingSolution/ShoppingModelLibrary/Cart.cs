

namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public int CartOwner {  get; set; }

        public Cart(int id, List<Product> products, int cartOwner) {
            Id = id;    
            Products = products;
            CartOwner = cartOwner;
        }
    }
}
