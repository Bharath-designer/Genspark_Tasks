namespace PizzaHutClone.Exceptions
{
    public class NoCustomerFoundException: Exception
    {
        public NoCustomerFoundException(): base("Customer not found for given Id") { }
    }
}
