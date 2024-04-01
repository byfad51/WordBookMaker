namespace Entities.Exceptions;

public class WordNoteBadDeleteRequestException : BadDeleteRequestException
{
    public WordNoteBadDeleteRequestException(int id) : base($"Word note id : {id} not found to delete.")
    {
    }
}