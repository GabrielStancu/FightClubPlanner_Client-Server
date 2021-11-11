using Core.Models;
using System.Threading.Tasks;

namespace Infrastructure.TournamentStrategies
{
    public interface ITournamentScheduler
    {
        Task<bool> AddFight(IMatchStrategy strategy, Tournament tournament);
        Task<Tournament> Build(Tournament tournament);
    }
}