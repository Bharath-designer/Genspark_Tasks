
namespace ShoppingModelLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderedProduct> Products { get; set; }
        public DateTime CreatedOn { get; set; }
        public Currency Currency { get; set; }
        public double TotalAmount { get; set; }

        public Order(int id, List<OrderedProduct> products, DateTime createdOn, Currency currency, double totalAmount)
        {
            Id = id;
            Products = products;
            CreatedOn = createdOn;
            Currency = currency;
            TotalAmount = totalAmount;
        }
    }
}
