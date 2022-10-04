using ErrorOr;
using FoodBnD.Application.Services.Authentication.Common;

namespace FoodBnD.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}