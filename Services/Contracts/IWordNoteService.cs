using Entities.Models;

namespace Services.Contracts;

public interface IWordNoteService
{
    Task CreateOneWordNote(WordNote wordNote);
    Task DeleteOneWordNote(WordNote wordNote);
    Task UpdateOneWordNote(WordNote wordNote);
    
    Task<WordNote> GetOneWordNoteById(int id, bool trackChanges);
    Task<List<WordNote>> GetAllWordsByWordId(int wordId, bool trackChanges);
    

}