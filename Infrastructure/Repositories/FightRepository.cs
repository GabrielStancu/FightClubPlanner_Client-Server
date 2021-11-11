using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FightRepository : GenericRepository<Fight>, IFightRepository
    {
        public FightRepository(FightClubContext context) : base(context) { }

        public async Task<List<Fight>> SelectAllFightsAsync()
        {
            return await
                Context.Fight
                    .Include(f => f.Tournament)
                    .ToListAsync();
        }

        public async Task<List<Fight>> SelectAllFightsByTournamentIdAsync(int id)
        {
            var fights = await
                Context.Fight
                    .Where(f => f.TournamentId == id)
                    .OrderByDescending(f => f.FightTime)
                    .ToListAsync();
            return await AddFightersToFight(fights);
        }

        public async Task<List<Fight>> SelectAllFightsByFighterIdAsync(int id)
        {
            var fights = await
                Context.Fight
                    .Where(f => f.FighterId1 == id || f.FighterId2 == id)
                    .Include(f => f.Tournament)
                    .ToListAsync();

            return await AddFightersToFight(fights);
        }

        public async Task<int> SelectCountOfFightsBetweenFightersInTournamentAsync(int fighter1Id, int fighter2Id, int tournamentId)
        {
            return await
                Context.Fight
                    .Where(f => ((f.FighterId1 == fighter1Id && f.FighterId2 == fighter2Id)
                                || (f.FighterId1 == fighter2Id && f.FighterId2 == fighter1Id))
                                && f.TournamentId == tournamentId).CountAsync();
        }

        private async Task<List<Fight>> AddFightersToFight(List<Fight> fights)
        {
            var fighters = await
                Context.Fighter
                    .ToListAsync();

            foreach (var fight in fights)
            {
                fight.Fighter1 = fighters.FirstOrDefault(f => f.Id == fight.FighterId1);
                fight.Fighter2 = fighters.FirstOrDefault(f => f.Id == fight.FighterId2);
                fight.Winner = fighters.FirstOrDefault(f => f.Id == fight.WinnerId);
            }

            return fights;
        }
    }
}
