using School.Data.Models.Identity;

namespace School.infrastructure.Abstract
{
    public interface IRefreshTokenInfrastrucure : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
