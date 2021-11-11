using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IInviteRepository : IGenericRepository<Invite>
    {
        Task<List<Invite>> SelectAllInvitesByFighterIdAsync(int id);
        Task<List<Invite>> SelectAllInvitesByTournamentIdAsync(int id);
    }
}