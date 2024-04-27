namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public Cart(int id, List<Product> products) {
            Id = id;    
            Products = products;
        }
    }
}
