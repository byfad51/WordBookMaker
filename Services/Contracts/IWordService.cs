using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IWordService
{
    Task<PagedList<WordResponseForDto>> GetAllWords(WordParameters wordParameters, bool trackChanges);
    Task<PagedList<Word>> GetAllWordsDetailed(WordParameters wordParameters, bool trackChanges);

    Task<WordForDto> CreateOneWord(WordForDto wordForDto);
    Task DeleteOneWord(int wordId);
    Task UpdateOneWord(int id, WordForDto wordForDto, bool trackChanges);

    Task<WordResponseForDto> GetOneWordById(int id, bool trackChanges);

    Task<Word> GetOneWordWithNotesById(int id, bool trackChanges);

}