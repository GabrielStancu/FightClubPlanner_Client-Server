using Core.Models;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IManagerRepository : IUserRepository<Manager>
    {
        new Task<int> SelectUserWithLoginInformationAsync(string username, string password);
    }
}