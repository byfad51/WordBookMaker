namespace Entities.Exceptions;

public class WordBadUpdateRequestException : BadUpdateRequestException
{
    public WordBadUpdateRequestException(int id) : base($"Word id : {id} could not found to update. Probably you are trying to update another word with wrong id.")
    {
    }
}