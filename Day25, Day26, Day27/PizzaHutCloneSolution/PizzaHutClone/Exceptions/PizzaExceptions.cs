namespace PizzaHutClone.Exceptions
{
    public class NoPizzaFoundException: Exception
    {  
        public NoPizzaFoundException(): base("Pizza not found for given Id") { }
    }
}
