using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Presentations.ActionFilters;
using Services.Contracts;

namespace UserSaver;

[ServiceFilter(typeof(LogFilterAttribute))]
[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;

    public AuthenticationController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
    {
        var result =await _service.AuthenticationService.RegisterUser(userForRegistrationDto);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code,error.Description);
            }

            return BadRequest(ModelState);
        }

        return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
        {
            return Unauthorized();
        }

        return Ok(new
        {
            Token = await _service.AuthenticationService.CreateToken()
        });
    }
    
}