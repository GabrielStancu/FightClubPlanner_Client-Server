using Infrastructure.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IManagerService
    {
        Task<IReadOnlyList<TournamentDTO>> SelectTournamentsForManagerAsync(int id);
    }
}