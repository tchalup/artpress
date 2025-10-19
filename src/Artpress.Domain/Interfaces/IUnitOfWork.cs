using System.Threading.Tasks;

namespace Artpress.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserClaimRepository UserClaims { get; }
        Task<int> CommitAsync();
    }
}
