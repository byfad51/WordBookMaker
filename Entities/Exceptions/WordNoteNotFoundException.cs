namespace Entities.Exceptions;

public class WordNoteNotFoundException : NotFoundException
{
    protected WordNoteNotFoundException(int id) : base($"Word id : {id} not found exception.")
    {
    }
}