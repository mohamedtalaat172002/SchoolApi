using School.Data.Models.Identity;
using School.Data.Result;

namespace School.Service.Abstract
{
    public interface IAuthenticationService
    {
        public Task<JwtResult> GenerateJwtToken(User user);
    }
}
