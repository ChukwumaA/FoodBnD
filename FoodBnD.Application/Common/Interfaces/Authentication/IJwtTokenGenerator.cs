using FoodBnD.Domain.Entities;

namespace FoodBnD.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}