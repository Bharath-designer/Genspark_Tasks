namespace ClinicTestCaseBLLibrary
{
    public class IdNotFoundException: Exception
    {
       public IdNotFoundException(string message) : base(message) { }
    }

    public class IdAlreadyFoundException: Exception
    {
        public IdAlreadyFoundException(string message) : base(message) { }
    }
}
