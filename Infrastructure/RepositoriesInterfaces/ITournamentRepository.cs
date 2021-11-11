using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ITournamentRepository : IGenericRepository<Tournament>
    {
        Task<List<Tournament>> SelectAllTournamentsAsync();
        Task<List<Tournament>> SelectTournamentsByManagerIdAsync(int id);
        Task<bool> TournamentNameTaken(string name);
        Task<Tournament> SelectTournamentWithDetailsByIdAsync(int id);
    }
}