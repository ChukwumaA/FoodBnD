using MediatR;
using ErrorOr;
using FoodBnD.Application.Common.Interfaces.Authentication;
using FoodBnD.Application.Common.Interfaces.Persistence;
using FoodBnD.Application.Services.Authentication.Common;
using FoodBnD.Domain.Common.Errors;
using FoodBnD.Domain.Entities;

namespace FoodBnD.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        // 2. Validate the password is correct
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
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