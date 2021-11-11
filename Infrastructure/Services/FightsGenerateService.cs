using Core.Models;
using Infrastructure.Repositories;
using Infrastructure.TournamentStrategies;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FightsGenerateService : IFightsGenerateService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IFightRepository _fightRepository;
        private readonly ITournamentScheduler _tournamentScheduler;
        private readonly IMatchGenerator _matchGenerator;

        public FightsGenerateService(ITournamentRepository tournamentRepository, IFightRepository fightRepository,
            ITournamentScheduler tournamentScheduler, IMatchGenerator matchGenerator)
        {
            _tournamentRepository = tournamentRepository;
            _fightRepository = fightRepository;
            _tournamentScheduler = tournamentScheduler;
            _matchGenerator = matchGenerator;
        }
        public async Task<bool> GenerateFightsAsync(IMatchStrategy matchStrategy, int tournamentId)
        {
            var tournament = await _tournamentRepository.SelectTournamentWithDetailsByIdAsync(tournamentId);

            for (int i = 0; i < 2; i++)
            {
                if ((await _tournamentScheduler.AddFight(matchStrategy, tournament)) == false)
                {
                    return false;
                }
            }

            await _tournamentScheduler.Build(tournament);

            return true;
        }

        public async Task<bool> RescheduleFights(int tournamentId)
        {
            var fights = await _fightRepository.SelectAllFightsByTournamentIdAsync(tournamentId);
            foreach (var fight in fights)
            {
                if (fight.FightTime == DateTime.Today)
                {
                    if(!fight.Fighter1.CanFight(DateTime.Today) || !fight.Fighter2.CanFight(DateTime.Today))
                    {
                        (Fighter fighter1, Fighter fighter2) = await _matchGenerator.GetBestMatch(tournamentId, fights);

                        if (fighter1.Id == 0 || fighter2.Id == 0)
                        {
                            return false;
                        }

                        fight.FighterId1 = fighter1.Id;
                        fight.FighterId2 = fighter2.Id;
                        await _fightRepository.UpdateAsync(fight);
                    }
                }
            }

            return true;
        }
    }
}
