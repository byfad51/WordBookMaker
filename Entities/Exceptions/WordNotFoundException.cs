namespace Entities.Exceptions;

public class WordNotFoundException : NotFoundException
{
    public WordNotFoundException(int id) : base($"Word note id : {id} not found exception.")
    {
    }
}