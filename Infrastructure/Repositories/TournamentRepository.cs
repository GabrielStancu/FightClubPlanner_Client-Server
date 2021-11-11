using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(FightClubContext context) : base(context) { }

        public async Task<List<Tournament>> SelectAllTournamentsAsync()
        {
            return await
                Context.Tournament
                    .Include(t => t.Organizer)
                    .Include(t => t.Fights).ThenInclude(f => f.Winner)
                    .Include(t => t.TournamentFighters).ThenInclude(tf => tf.Fighter)
                    .ToListAsync();
        }

        public async Task<List<Tournament>> SelectTournamentsByManagerIdAsync(int managerId)
        {
            return await
                Context.Tournament
                    .Where(t => t.OrganizerId == managerId)
                    .ToListAsync();
        }

        public async Task<Tournament> SelectTournamentWithDetailsByIdAsync(int id)
        {
            var tournament = await Context.Tournament
                    .Include(t => t.Fights)
                    .Include(t => t.TournamentFighters).ThenInclude(tf => tf.Fighter).ThenInclude(f => f.TestHistory)
                    .Where(t => t.Id == id)
                    .FirstOrDefaultAsync();

            if (tournament != null)
            {
                tournament.Fighters = new List<Fighter>();
                foreach (var tf in tournament.TournamentFighters)
                {
                    var fighter = tf.Fighter;
                    fighter.IsEligible = fighter.CanFight(DateTime.Today);
                    tournament.Fighters.Add(fighter);
                }

                foreach(var fight in tournament.Fights)
                {
                    var fighter1 = tournament.Fighters.FirstOrDefault(f => f.Id == fight.FighterId1);
                    var fighter2 = tournament.Fighters.FirstOrDefault(f => f.Id == fight.FighterId2);

                    fight.Fighter1 = fighter1;
                    fight.Fighter2 = fighter2;
                }
            }

            return tournament;
        }

        public async Task<bool> TournamentNameTaken(string name)
        {
            return await
                Context.Tournament
                    .Where(t => t.Name.Equals(name))
                    .FirstOrDefaultAsync() != null;
        }
    }
}
