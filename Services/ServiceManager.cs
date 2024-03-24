using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<AuthenticationManager> _authenticationService;
    private readonly Lazy<IWordService> _words;
    private readonly Lazy<IWordNoteService> _wordNotes;

    
    public ServiceManager(IRepositoryManager repositoryManager,IConfiguration configuration, UserManager<User> userManager, IMapper mapper)
    {
        _authenticationService = new Lazy<AuthenticationManager>(()=> new AuthenticationManager(configuration, userManager, mapper));
        _words = new Lazy<IWordService>(() => new WordManager(repositoryManager,mapper));
        _wordNotes = new Lazy<IWordNoteService>(() => new WordNoteManager(repositoryManager,mapper));

    }    


    public IAuthenticationService AuthenticationService => _authenticationService.Value;
    public IWordService Words => _words.Value;

    public IWordNoteService WordNotes => _wordNotes.Value;
}