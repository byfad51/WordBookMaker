namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IWordRepository Word { get; }
    Task SaveAsync();

}