using FoodBnD.Application.Services.Authentication.Common;
using MediatR;
using ErrorOr;
 
namespace FoodBnD.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

