using School.Data.Models.Identity;

namespace School.Service.Abstract
{
    public interface IAuthenticationService
    {
        public Task<String> GenerateJwtToken(User user);
    }
}
