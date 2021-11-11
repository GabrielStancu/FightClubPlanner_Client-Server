using Infrastructure.TournamentStrategies;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IFightsGenerateService
    {
        Task<bool> GenerateFightsAsync(IMatchStrategy matchStrategy, int tournamentId);
        Task<bool> RescheduleFights(int tournamentId);
    }
}