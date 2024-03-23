using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public record UserForAuthenticationDto
{
    [Required(ErrorMessage = "Username is needed.")]
    public string? UserName{ get; init; }
    
    [Required(ErrorMessage = "Password is needed.")]

    public string? Password{ get; init; }
}