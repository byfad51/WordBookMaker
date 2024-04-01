using AutoMapper;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class WordNoteManager : IWordNoteService

{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public WordNoteManager(IRepositoryManager manager,
        IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }
    
    public async Task CreateOneWordNote(WordNote wordNote)
    {
       var entity = await _manager.Word.GetOneWordById(wordNote.WordId,false);
       if (entity is null)
           throw new Exception("Word not found exception.");
       if(wordNote is null)
           throw new Exception("WordNote not needed exception.");

       _manager.WordNote.CreateOneWordNote(wordNote);
       await _manager.SaveAsync();
    }

    public async Task DeleteOneWordNote(WordNote wordNote)
    {
        if(wordNote is null)
            throw new Exception("WordNote not needed exception.");
        var entity =await _manager.WordNote.GetOneWordNoteById(wordNote.WordNoteId, false);
        if(entity is null)
            throw new Exception("WordNote not found exception.");

        _manager.WordNote.DeleteOneWordNote(wordNote);
        await _manager.SaveAsync();
        // saveasync i kontrol et bi
    }

    public async Task UpdateOneWordNote(WordNote wordNote, bool trackChanges)
    {
        if(wordNote is null)
            throw new Exception("WordNote not needed exception.");
        var entity =await _manager.WordNote.GetOneWordNoteById(wordNote.WordNoteId, trackChanges);
        if(entity is null)
            throw new Exception("WordNote not found exception.");
        _manager.WordNote.UpdateOneWordNote(wordNote,true);
        await _manager.SaveAsync();
        // saveasync i kontrol et bi

    }

    public async Task<WordNote> GetOneWordNoteById(int id, bool trackChanges)
    {
        var entity = await _manager.WordNote.GetOneWordNoteById(id, false);
        if(entity is null)
            throw new Exception("WordNote not found exception.");
        return entity;
    }

    public async Task<List<WordNote>> GetAllWordsByWordId(int wordId, bool trackChanges)
    {
       var entity = await _manager.Word.GetOneWordById(wordId,false);
        if(entity is null)
            throw new Exception("Word not found exception.");
        var entities = await _manager.WordNote.GetAllWordNotesByWordId(wordId, false);
        return entities;
    }
}