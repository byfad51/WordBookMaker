using System.Linq.Expressions;
using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface IWordRepository : IRepositoryBase<Word>
{
    void CreateOneWord(Word word);
    void UpdateOneWord(Word word);
    void DeleteOneWord(Word word);

    Task<Word> GetOneWordById(int id, bool trackChanges);
    Task<List<Word>> GetAllWords(bool trackChanges);
    Task<PagedList<Word>> GetAllWords(WordParameters wordParameters, bool trackChanges);
    
    Task<PagedList<Word>> GetAllWordsDetailed(WordParameters wordParameters, bool trackChanges);


    Task<Word> GetOneWordWithNotesById(int id, bool trackChanges);
}