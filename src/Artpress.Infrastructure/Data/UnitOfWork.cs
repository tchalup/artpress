using System.Threading.Tasks;
using Artpress.Domain.Interfaces;
using Artpress.Infrastructure.Data.Context;
using Artpress.Infrastructure.Data.Repositories;

namespace Artpress.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArtpressDbContext _context;
        private IUserRepository _userRepository;
        private IUserClaimRepository _userClaimRepository;

        public UnitOfWork(ArtpressDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        public IUserClaimRepository UserClaims => _userClaimRepository ??= new UserClaimRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
