
namespace ShoppingModelLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public OrderedProduct Product { get; set; }
        public DateTime CreatedOn { get; set; }
        public Currency Currency { get; set; }
        public double TotalAmount { get; set; }

        public Order(int id, OrderedProduct product, DateTime createdOn, Currency currency, double totalAmount)
        {
            Id = id;
            Product = product;
            CreatedOn = createdOn;
            Currency = currency;
            TotalAmount = totalAmount;
        }
    }
}
