using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager:IRepositoryManager
{
    private readonly Lazy<IWordRepository> _wordRepository;
    private readonly Lazy<IWordNoteRepository> _wordNoteRepository;

    private readonly RepositoryContext _context;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _context = repositoryContext;
        _wordRepository = new Lazy<IWordRepository>(() => new WordRepository(_context));
        _wordNoteRepository = new Lazy<IWordNoteRepository>(() => new WordNoteRepository(_context));

    }

    public IWordRepository Word => _wordRepository.Value;
    public IWordNoteRepository WordNote => _wordNoteRepository.Value;


    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}