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

    public async Task<PagedList<WordResponseForDto>> GetAllWords(WordParameters wordParameters, bool trackChanges)
    {
        var entities = await _manager.Word.GetAllWords(wordParameters, trackChanges);

        var responseEntities = _mapper.Map<IEnumerable<WordResponseForDto>>(entities);
        var list = PagedList<WordResponseForDto>.ToPagedList(responseEntities, wordParameters.PageNumber,wordParameters.PageSize);
        return list;
    } // THERE IS AN ERROR

    public async Task<PagedList<Word>> GetAllWordsDetailed(WordParameters wordParameters, bool trackChanges)
    {
        return await _manager.Word.GetAllWordsDetailed(wordParameters, trackChanges);
    }


    public async Task<WordForDto> CreateOneWord(WordForDto wordForDto)
    {
        if (wordForDto is null)
            throw new Exception("Null word error!");
        var entity = _mapper.Map<Word>(wordForDto);
        _manager.Word.CreateOneWord(entity);
        await _manager.SaveAsync();
        return _mapper.Map<WordForDto>(entity);
    }

    public void DeleteOneWord(Word word)
    {
        var entity = _manager.Word.GetOneWordById(word.WordId,false);
        if (entity is null)
            throw new Exception("Word not found");

        _manager.Word.DeleteOneWord(word);
    }

  

    public void UpdateOneWord(Word word, bool trackChanges)
    {
        if(word is null)
            throw new Exception("Null word error!");
        var entity = _manager.Word.GetOneWordById(word.WordId,trackChanges);
        if (entity is null)
            throw new Exception("Word not found");
        
        _manager.Word.UpdateOneWord(word);
    }

 

    public async Task<WordResponseForDto> GetOneWordById(int id, bool trackChanges)
    {
        var entity = await _manager.Word.GetOneWordById(id,trackChanges);
        if (entity is null)
            throw new Exception("Word not found"); 
        var entityDto = _mapper.Map<WordResponseForDto>(entity);

        return entityDto;
    }

    public async Task<Word> GetOneWordWithNotesById(int id, bool trackChanges)
    {
        var entity = await _manager.Word.GetOneWordWithNotesById(id,trackChanges);
        if (entity is null)
            throw new Exception("Word not found");

        return entity;
        
    }
}