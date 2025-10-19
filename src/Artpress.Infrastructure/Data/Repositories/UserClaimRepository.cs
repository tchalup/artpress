using Artpress.Domain.Entities;
using Artpress.Domain.Interfaces;
using Artpress.Infrastructure.Data.Context;

namespace Artpress.Infrastructure.Data.Repositories
{
    public class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(ArtpressDbContext context) : base(context)
        {
        }

        // Implementação de métodos específicos para UserClaim, se necessário
    }
}
