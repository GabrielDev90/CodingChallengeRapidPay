using System.Security.Claims;

namespace RapidPay.Service.Identity.Service
{
    public interface IJWTokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}