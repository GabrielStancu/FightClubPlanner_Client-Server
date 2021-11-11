using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ManagerRepository : UserRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(FightClubContext context) : base(context) { }

        public async override Task<int> SelectUserWithLoginInformationAsync(string username, string password)
        {
            var manager = await
                Context.Manager
                    .Include(m => m.Tournaments)
                    .Where(m => m.Username.Equals(username)
                        && m.Password.Equals(password))
                    .FirstOrDefaultAsync();

            return manager == null ? 0 : manager.Id;
        }
    }
}
