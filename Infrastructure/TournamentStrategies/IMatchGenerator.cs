using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.TournamentStrategies
{
    public interface IMatchGenerator
    {
        Task<(Fighter Fighter1, Fighter Fighter2)> GetBestMatch(int tournamentId, List<Fight> pendingFights);
    }
}