namespace Entities.Exceptions;

public class WordBadDeleteRequestException : BadDeleteRequestException
{
    public WordBadDeleteRequestException(int id) : base($"Word id : {id} not found to delete.")
    {
    }
}