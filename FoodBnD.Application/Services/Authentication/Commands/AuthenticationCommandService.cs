
using ErrorOr;
using FoodBnD.Application.Common.Interfaces.Authentication;
using FoodBnD.Application.Common.Interfaces.Persistence;
using FoodBnD.Application.Services.Authentication.Common;
using FoodBnD.Domain.Common.Errors;
using FoodBnD.Domain.Entities;

namespace FoodBnD.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        // 2. Validate the password is correct
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        
        _userRepository.Add(user);
        // 3 Create the JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(
            user,
            token
        );
    }
}