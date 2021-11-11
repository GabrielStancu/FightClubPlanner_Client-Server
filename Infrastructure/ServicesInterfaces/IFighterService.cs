using Infrastructure.DTOs;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IFighterService
    {
        Task<DetailedFighterDTO> GetFighterWithDetailsAsync(int id);
    }
}