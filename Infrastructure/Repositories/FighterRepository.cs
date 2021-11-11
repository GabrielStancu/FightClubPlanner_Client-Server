using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FighterRepository : UserRepository<Fighter>, IFighterRepository
    {
        private readonly ITournamentFighterRepository _tournamentFighterRepository;
        private readonly IFightRepository _fightRepository;

        public FighterRepository(FightClubContext context, ITournamentFighterRepository tournamentFighterRepository,
            IFightRepository fightRepository) : base(context)
        {
            _tournamentFighterRepository = tournamentFighterRepository;
            _fightRepository = fightRepository;
        }

        public async override Task<int> SelectUserWithLoginInformationAsync(string username, string password)
        {
            var fighter = await
                Context.Fighter
                    .FirstOrDefaultAsync(
                        f => f.Username.Equals(username)
                        && f.Password.Equals(password)
                    );

            return fighter == null ? 0 : fighter.Id;
        }

        public async Task<Fighter> SelectFighterWithDataAsync(int id)
        {
            var fighter = await
                Context.Fighter
                    .Include(f => f.TestHistory).ThenInclude(t => t.IsolationBubble)
                    .Include(f => f.TournamentFighters).ThenInclude(tf => tf.Tournament)
                    .Include(f => f.Invites).ThenInclude(i => i.Tournament)
                    .FirstOrDefaultAsync(
                        f => f.Id == id);

            if (fighter is null)
            {
                return null;
            }

            fighter.SetTournaments();
            fighter.FightHistory = await _fightRepository.SelectAllFightsByFighterIdAsync(fighter.Id);
            fighter.IsEligible = fighter.CanFight(DateTime.Today);

            return fighter;
        }

        public async Task<List<Fighter>> SelectAllFightersAsync()
        {
            return await
                Context.Fighter
                    .Include(f => f.TestHistory)
                    .ToListAsync();
        }

        public async Task<List<Fighter>> SelectAllFightersFromTournamentAsync(int tournamentId)
        {
            var fighters = new List<Fighter>();
            var tournamentFighters = await _tournamentFighterRepository.SelectAllFightersByTournamentIdAsync(tournamentId);
            tournamentFighters.ForEach(tf => fighters.Add(tf.Fighter));

            return fighters;
        }

        public async Task<Fighter> SelectFighterWithTestsHistoryAsync(int id)
        {
            return await
                Context.Fighter
                    .Include(f => f.TestHistory)
                    .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
