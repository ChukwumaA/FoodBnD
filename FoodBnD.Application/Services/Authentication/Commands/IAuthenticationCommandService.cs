using ErrorOr;
using FoodBnD.Application.Services.Authentication.Common;

namespace  FoodBnD.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}