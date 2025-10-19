using Artpress.Domain.Entities;
using Artpress.Domain.Interfaces;
using Artpress.Infrastructure.Data.Context;

namespace Artpress.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ArtpressDbContext context) : base(context)
        {
        }

        // Implementação de métodos específicos para User, se necessário
    }
}
