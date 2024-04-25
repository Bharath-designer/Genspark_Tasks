namespace ShoppingModelLibrary
{
    public class OrderedProduct
    {
        
        public Product Product {  get; set; }

        public double TotalAmount { get; set; }

        public int Quantity { get; set; }

        public OrderedProduct(Product product, double amount, int quantity)
        {
            Product = product; 
            TotalAmount = amount;
            Quantity = quantity;
        }
    }
}
