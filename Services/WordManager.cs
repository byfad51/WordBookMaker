using System.Globalization;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
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

        var responseEntities = entities.Select(word => _mapper.Map<WordResponseForDto>(word)).ToList();

        var responsePagedList = new PagedList<WordResponseForDto>(responseEntities,entities.MetaData.TotalSize,wordParameters.PageNumber,wordParameters.PageSize);
        //var list = PagedList<WordResponseForDto>.ToPagedList(responseEntities, wordParameters.PageNumber,wordParameters.PageSize);
        return responsePagedList;
    }

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

    public async Task DeleteOneWord(int wordId)
    {
        var entity = await _manager.Word.GetOneWordById(wordId,false);
        if (entity is null)
            throw new WordNotFoundException(wordId);
    
        _manager.Word.DeleteOneWord(entity);
        await _manager.SaveAsync();
    }

  

    public async Task UpdateOneWord(int id, WordForDto wordForDto, bool trackChanges)
    {
        if(wordForDto is null)
            throw new Exception("Null word error!");
        var entity = await _manager.Word.GetOneWordById(id,trackChanges);
        if (entity is null)
            throw new WordNotFoundException(id);
        var newWord = _mapper.Map<Word>(wordForDto);
        _manager.Word.UpdateOneWord(newWord);
        await _manager.SaveAsync();
    }

 

    public async Task<WordResponseForDto> GetOneWordById(int id, bool trackChanges)
    {
        var entity = await _manager.Word.GetOneWordById(id,trackChanges);
        if (entity is null)
            throw new WordNotFoundException(id); 
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