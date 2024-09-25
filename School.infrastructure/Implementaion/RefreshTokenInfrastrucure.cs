using Microsoft.EntityFrameworkCore;
using School.Data.Models.Identity;
using School.infrastructure.Abstract;
using School.infrastructure.Context;

namespace School.infrastructure.Implementaion
{
    public class RefreshTokenInfrastrucure : GenericRepositoryAsync<UserRefreshToken>,
                                            IRefreshTokenInfrastrucure
    {
        private readonly DbSet<UserRefreshToken> _dbSet;
        public RefreshTokenInfrastrucure(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<UserRefreshToken>();
        }
    }
}
