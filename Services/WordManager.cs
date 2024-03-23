using System.Globalization;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class WordManager : IWordService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public WordManager(IRepositoryManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<PagedList<Word>> GetAllWords(WordParameters wordParameters, bool trackChanges)
    {
      return await _manager.Word.GetAllWords(wordParameters, trackChanges);
    }

    public async Task<PagedList<Word>> GetAllWordsDetailed(WordParameters wordParameters, bool trackChanges)
    {
        return await _manager.Word.GetAllWords(wordParameters, trackChanges);
    }


    public async Task<Word> CreateOneWord(Word word)
    {
        if (word is null)
            throw new Exception("Null word error!");
        _manager.Word.CreateOneWord(word);
        await _manager.SaveAsync();
        return word;
    }

    public void DeleteOneWord(Word word)
    {
        var entity = _manager.Word.GetOneWordById(word.Id,false);
        if (entity is null)
            throw new Exception("Word not found");

        _manager.Word.DeleteOneWord(word);
    }

  

    public void UpdateOneWord(Word word, bool trackChanges)
    {
        if(word is null)
            throw new Exception("Null word error!");
        var entity = _manager.Word.GetOneWordById(word.Id,trackChanges);
        if (entity is null)
            throw new Exception("Word not found");
        
        _manager.Word.UpdateOneWord(word);
    }

 

    public async Task<Word> GetOneWordById(int id, bool trackChanges)
    {
        var entity = await _manager.Word.GetOneWordById(id,trackChanges);
        if (entity is null)
            throw new Exception("Word not found");

        return entity;
    }

    public async Task<Word> GetOneWordWithNotesById(int id, bool trackChanges)
    {
        var entity = await _manager.Word.GetOneWordWithNotesById(id,trackChanges);
        if (entity is null)
            throw new Exception("Word not found");

        return entity;
        
    }
}