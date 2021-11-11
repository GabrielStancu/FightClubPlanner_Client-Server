using Infrastructure.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IInvitableFightersSelectService
    {
        Task<IReadOnlyList<FighterDTO>> SelectInvitableFightersAsync(int tournamentId);
    }
}