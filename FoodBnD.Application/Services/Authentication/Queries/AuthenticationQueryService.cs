using ErrorOr;
using FoodBnD.Application.Common.Interfaces.Authentication;
using FoodBnD.Application.Common.Interfaces.Persistence;
using FoodBnD.Application.Services.Authentication.Common;
using FoodBnD.Domain.Common.Errors;
using FoodBnD.Domain.Entities;

namespace FoodBnD.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }
        // 2. Validate the password is correct
        if (user.Password != password)
        {
            return new[]{ Errors.Authentication.InvalidCredential };
        }
        // 3 Create the JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token
            );
    }

}