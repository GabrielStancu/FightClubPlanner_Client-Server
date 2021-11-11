using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InviteRepository : GenericRepository<Invite>, IInviteRepository
    {
        public InviteRepository(FightClubContext context) : base(context) { }

        public async Task<List<Invite>> SelectAllInvitesByFighterIdAsync(int id)
        {
            return await Context.Invite
                .Where(i => i.FighterId == id)
                .Include(i => i.Tournament).ThenInclude(t => t.Organizer)
                .ToListAsync();
        }

        public async Task<List<Invite>> SelectAllInvitesByTournamentIdAsync(int id)
        {
            return await Context.Invite
                .Where(i => i.TournamentId == id)
                .Include(i => i.Fighter)
                .ToListAsync();
        }
    }
}
