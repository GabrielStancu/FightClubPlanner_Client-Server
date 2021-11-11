using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IFightRepository : IGenericRepository<Fight>
    {
        Task<List<Fight>> SelectAllFightsAsync();
        Task<List<Fight>> SelectAllFightsByFighterIdAsync(int id);
        Task<List<Fight>> SelectAllFightsByTournamentIdAsync(int id);
        Task<int> SelectCountOfFightsBetweenFightersInTournamentAsync(int fighter1Id, int fighter2Id, int tournamentId);
    }
}