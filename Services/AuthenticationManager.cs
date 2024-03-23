using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;

namespace Services;

public class AuthenticationManager :IAuthenticationService
{
    //logger eklenecek
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    private User? _user;

    public AuthenticationManager(IConfiguration configuration, UserManager<User> userManager, IMapper mapper)
    {
        _configuration = configuration;
        _userManager = userManager;
        _mapper = mapper;
    }


    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
    {
        var user = _mapper.Map<User>(userForRegistrationDto);

        var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);

        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);

        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
    {
        _user = await _userManager.FindByNameAsync(userForAuthenticationDto.UserName);
        var result = (_user != null) &&
                     (await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));
        if (!result)
        {
         //burada log düşülebilir, giriş başarısız diye..   
        }

        return result;
    }

    public async Task<string> CreateToken()
    {
        var signinCredantials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptins = GenerateTokenOptions(signinCredantials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptins);
    }

    

    private SigningCredentials GetSigningCredentials()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

       var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);

       var secret = new SymmetricSecurityKey(key);
       return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,_user.UserName)
        };
        var roles = await _userManager.GetRolesAsync(_user);
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role,role));

        }
        //claims.Add(new Claim(ClaimTypes.Country,"Türkiye"));
        /// bu şekilde yapılan eklemeler, token içerisine gömülür
        return claims;
    }
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredantials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenOptions = new JwtSecurityToken(
            issuer:jwtSettings["validIssuer"], claims:claims,audience:jwtSettings["validAudience"],expires:DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),signingCredentials:signinCredantials);

        return tokenOptions;
    }
}