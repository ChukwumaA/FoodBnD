using FoodBnD.Domain.Entities;

namespace FoodBnD.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);