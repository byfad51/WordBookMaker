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


    public async Task<WordNote> GetOneWordNoteById(int id, int wordId, bool trackChanges) =>
        await FindByCondition(b => b.Id.Equals(wordId) && b.WordId.Equals(wordId),trackChanges).SingleOrDefaultAsync();

    public async Task<IQueryable<WordNote>> GetAllWordNotesById(int wordId, bool trackChanges) =>
         FindByCondition(b => b.WordId.Equals(wordId), trackChanges).AsSingleQuery();

    public async Task<List<WordNote>> GetAllWordNotes(bool trackChanges) => await FindAll(trackChanges).ToListAsync();
    
}