namespace ShoppingModelLibrary
{
    public enum Currency
    {
        Rupee,
        Dollar
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; } 
        public double Price { get; set; }

        public Product(int id, string name, Currency currency, double price)
        {
            Id = id;
            Name = name;
            Currency = currency;
            Price = price;
        }
    }
}
