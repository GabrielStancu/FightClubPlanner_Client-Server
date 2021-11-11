using Infrastructure.DTOs;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ITournamentService
    {
        Task<bool> AddTournamentAsync(AddTournamentDTO addTournamentDTO);
        Task<DetailedTournamentDTO> GetTournamentInfoAsync(int id);
        Task SetFightWinnerAsync(FightDTO fightDTO);
    }
}