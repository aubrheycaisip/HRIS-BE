using HRIS_BE.Helpers.Models;

namespace HRIS_BE.Helpers.Interfaces
{
    public interface IJwtService
    {
        public TokenModel GenerateJwtToken(UserLogin username);
    }
}
