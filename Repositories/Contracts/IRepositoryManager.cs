namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IWordRepository Word { get; }
    IWordNoteRepository WordNote { get; }
    Task SaveAsync();

}