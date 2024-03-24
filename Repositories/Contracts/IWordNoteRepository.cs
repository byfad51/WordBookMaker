using Entities.Models;

namespace Repositories.Contracts;

public interface IWordNoteRepository
{
    void CreateOneWordNote(WordNote wordNote);
    void UpdateOneWordNote(WordNote wordNote, bool trackChanges);
    void DeleteOneWordNote(WordNote wordNote);

    Task<WordNote> GetOneWordNoteById(int id, bool trackChanges);
    Task<List<WordNote>> GetAllWordNotesByWordId(int wordId, bool trackChanges);
    Task<List<WordNote>> GetAllWordNotes(bool trackChanges);
}