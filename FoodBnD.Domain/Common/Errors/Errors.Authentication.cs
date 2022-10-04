using ErrorOr;

namespace FoodBnD.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredential => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid Credentials.");
    }
}

