using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ITournamentFighterRepository : IGenericRepository<TournamentFighter>
    {
        Task<List<TournamentFighter>> SelectAllFightersByTournamentIdAsync(int id);
        Task<List<TournamentFighter>> SelectAllTournamentsByFighterIdAsync(int id);
    }
}