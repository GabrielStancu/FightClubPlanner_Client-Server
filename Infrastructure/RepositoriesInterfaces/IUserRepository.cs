using Core.Models;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : User
    {
        Task<bool> CheckAlreadyRegisteredUserAsync(string username);
        Task RegisterUserAsync(T user);
        Task<int> SelectUserWithLoginInformationAsync(string username, string password);
    }
}