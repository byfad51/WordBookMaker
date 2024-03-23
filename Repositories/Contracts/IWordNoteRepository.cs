using Entities.Models;

namespace Repositories.Contracts;

public interface IWordNoteRepository
{
    void CreateOneWordNote(WordNote wordNote);
    void UpdateOneWordNote(WordNote wordNote, bool trackChanges);
    void DeleteOneWordNote(WordNote wordNote);

    Task<WordNote> GetOneWordNoteById(int id, int wordId, bool trackChanges);
    Task<IQueryable<WordNote>> GetAllWordNotesById(int wordId, bool trackChanges);
    Task<List<WordNote>> GetAllWordNotes(bool trackChanges);
}