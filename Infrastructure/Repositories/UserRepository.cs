using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository<T> : GenericRepository<T>, IUserRepository<T> where T : User
    {
        public UserRepository(FightClubContext context) : base(context) { }

        public virtual Task<int> SelectUserWithLoginInformationAsync(string username, string password) { return null; }
        public async Task<bool> CheckAlreadyRegisteredUserAsync(string username)
        {
            return await
                Context.Set<T>()
                    .FirstOrDefaultAsync(
                        u => u.Username.Equals(username)
                    ) != null;
        }

        public async Task RegisterUserAsync(T user)
        {
            await InsertAsync(user);
        }
    }
}
