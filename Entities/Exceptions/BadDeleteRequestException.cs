namespace Entities.Exceptions;

public class BadDeleteRequestException: Exception
{
    public BadDeleteRequestException(string message) : base(message)
    {
        
    }
}