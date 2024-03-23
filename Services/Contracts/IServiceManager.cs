namespace Services.Contracts;

public interface IServiceManager
{
    IAuthenticationService AuthenticationService { get; }
    
    IWordService Words { get; }
}