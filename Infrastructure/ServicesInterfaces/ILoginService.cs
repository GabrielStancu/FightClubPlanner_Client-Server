using Infrastructure.DTOs;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ILoginService
    {
        Task<LoginResultDTO> LoginAsync(string username, string password);
    }
}