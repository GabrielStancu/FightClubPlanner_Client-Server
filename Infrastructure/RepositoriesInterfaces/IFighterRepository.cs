using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IFighterRepository : IUserRepository<Fighter>
    {
        Task<List<Fighter>> SelectAllFightersAsync();
        Task<List<Fighter>> SelectAllFightersFromTournamentAsync(int tournamentId);
        new Task<int> SelectUserWithLoginInformationAsync(string username, string password);
        Task<Fighter> SelectFighterWithTestsHistoryAsync(int id);
        Task<Fighter> SelectFighterWithDataAsync(int id);
    }
}