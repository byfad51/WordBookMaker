using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class WordNoteRepository:RepositoryBase<WordNote>, IWordNoteRepository
{
    public WordNoteRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateOneWordNote(WordNote wordNote) => Create(wordNote);

    public void UpdateOneWordNote(WordNote wordNote, bool trackChanges) => Update(wordNote);
    
    public void DeleteOneWordNote(WordNote wordNote) => Delete(wordNote);


    public async Task<WordNote> GetOneWordNoteById(int id, bool trackChanges) =>
        await FindByCondition(b => b.WordNoteId.Equals(id), trackChanges).SingleOrDefaultAsync();
    public async Task<List<WordNote>> GetAllWordNotesByWordId(int wordId, bool trackChanges) =>
         await FindByCondition(b => b.WordId.Equals(wordId), trackChanges).ToListAsync();

    public async Task<List<WordNote>> GetAllWordNotes(bool trackChanges) => await FindAll(trackChanges).ToListAsync();
    
}