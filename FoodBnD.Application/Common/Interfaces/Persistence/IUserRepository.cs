using FoodBnD.Domain.Entities;

namespace  FoodBnD.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}