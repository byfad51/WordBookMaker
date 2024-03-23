using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IWordService
{
    Task<PagedList<Word>> GetAllWords(WordParameters wordParameters, bool trackChanges);
    Task<PagedList<Word>> GetAllWordsDetailed(WordParameters wordParameters, bool trackChanges);

    Task<Word> CreateOneWord(Word word);
    void DeleteOneWord(Word word);
    void UpdateOneWord(Word word, bool trackChanges);

    Task<Word> GetOneWordById(int id, bool trackChanges);

    Task<Word> GetOneWordWithNotesById(int id, bool trackChanges);

}