//using SportsTime365.core.Models;
using System.Security.Claims;

namespace SportsTime365.Authentication.Services
{
    public interface ITokenService
    {
        string GenerateToken(string Emiail, string Role);

        bool ValidateToken(string token);
        ClaimsPrincipal GetPrincipalFromToken(string token);
        // Other methods for token validation, refreshing, etc.
    }
}
