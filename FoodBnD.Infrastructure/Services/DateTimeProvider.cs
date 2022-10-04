using FoodBnD.Application.Common.Interfaces.Services;

namespace FoodBnD.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
