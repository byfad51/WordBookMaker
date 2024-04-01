namespace Entities.Exceptions;

public class WordNoteBadUpdateRequestException: BadUpdateRequestException
{
    public WordNoteBadUpdateRequestException(int id) : base($"Word note id : {id} could not found to update.")
    {
    }
}