namespace PizzaHutClone.Exceptions
{
    public class NoUserFoundException : Exception
    {
        public NoUserFoundException() : base("User not found for given Id") { }
    }

    public class UserEmailAlreadyRegisteredException: Exception
    {
        public UserEmailAlreadyRegisteredException() : base("Email is already exists") { }
    }
    
    public class UnauthorizedUserException: Exception
    {
        public UnauthorizedUserException() : base("Invalid username or password") { }
    }
}
