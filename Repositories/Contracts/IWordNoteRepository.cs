using Entities.Models;

namespace Repositories.Contracts;

public interface IWordNoteRepository
{
    void CreateOneWordNote(WordNote wordNote);
    void UpdateOneWordNote(WordNote wordNote);
    void DeleteOneWordNote(WordNote wordNote);

    Task<WordNote> GetOneWordNoteById(int id);
}