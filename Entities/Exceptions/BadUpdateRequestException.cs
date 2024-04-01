namespace Entities.Exceptions;

public class BadUpdateRequestException : Exception
{
    protected BadUpdateRequestException(string message): base(message)
    {
        
    }
}