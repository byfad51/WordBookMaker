using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class WordRepository: RepositoryBase<Word>, IWordRepository
{
    public WordRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateOneWord(Word word) => Create(word);
    public void UpdateOneWord(Word word) => Update(word);
    public void DeleteOneWord(Word word) => Delete(word);


    public async Task<Word> GetOneWordById(int id, bool trackChanges) => 
        await FindByCondition(b => b.Id.Equals(id),trackChanges).SingleOrDefaultAsync();

    public async Task<List<Word>> GetAllWords(bool trackChanges)
        => await FindAll(false).ToListAsync();
    


    public async Task<PagedList<Word>> GetAllWords(WordParameters wordParameters, bool trackChanges)
    {
        var words = await FindAll(false).OrderBy(b => b.Id).ToListAsync();
        var pagedWords = PagedList<Word>.ToPagedList(words,wordParameters.PageNumber,wordParameters.PageSize);
        return pagedWords;
    }

    public async Task<PagedList<Word>> GetAllWordsDetailed(WordParameters wordParameters, bool trackChanges)
    {
        var words = await FindAll(false).OrderBy(b => b.Id).Include(b=> b.Notes).ToListAsync();
        var pagedWords = PagedList<Word>.ToPagedList(words,wordParameters.PageNumber,wordParameters.PageSize);
        return pagedWords;    }

    public async Task<Word> GetOneWordWithNotesById(int id, bool trackChanges)
    => await FindByCondition(b => b.Id.Equals(id),trackChanges).Include(b=> b.Notes)
        .SingleOrDefaultAsync();
}