using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TournamentFighterRepository : GenericRepository<TournamentFighter>, ITournamentFighterRepository
    {
        public TournamentFighterRepository(FightClubContext context) : base(context) { }

        public async Task<List<TournamentFighter>> SelectAllTournamentsByFighterIdAsync(int id)
        {
            return await Context.TournamentFighter
                .Include(tf => tf.Tournament).ThenInclude(t => t.Organizer)
                .Where(tf => tf.FighterId == id)
                .ToListAsync();
        }

        public async Task<List<TournamentFighter>> SelectAllFightersByTournamentIdAsync(int id)
        {
            return await Context.TournamentFighter
                .Include(t => t.Fighter).ThenInclude(f => f.TestHistory)
                .Where(t => t.TournamentId == id)
                .ToListAsync();
        }
    }
}
