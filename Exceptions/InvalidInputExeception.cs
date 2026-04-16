public class InvalidProductException : Exception
{
    // Constructor with a custom message
    public InvalidProductException(string message) : base(message)
    {
    }
    // Constructor with a custom message and inner exception
    public InvalidProductException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
