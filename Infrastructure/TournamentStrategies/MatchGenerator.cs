using Core.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.TournamentStrategies
{
    public class MatchGenerator : IMatchGenerator
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IFightRepository _fightRepository;

        public MatchGenerator(IFighterRepository fighterRepository, IFightRepository fightRepository)
        {
            _fighterRepository = fighterRepository;
            _fightRepository = fightRepository;
        }
        public async Task<(Fighter Fighter1, Fighter Fighter2)> GetBestMatch(int tournamentId, List<Fight> pendingFights)
        {
            var fighters = await _fighterRepository.SelectAllFightersFromTournamentAsync(tournamentId);
            double minQuota = -1;
            Fighter fighter1 = new Fighter();
            Fighter fighter2 = new Fighter();

            foreach (var f1 in fighters)
            {
                if (!f1.CanFight(DateTime.Today))
                {
                    continue;
                }
                foreach (var f2 in fighters)
                {
                    if (!f2.CanFight(DateTime.Today))
                    {
                        continue;
                    }
                    if (f1 != f2)
                    {
                        double crtQuota = await ComputeQuota(f1, f2, tournamentId, pendingFights);

                        if (minQuota == -1 || crtQuota < minQuota)
                        {
                            minQuota = crtQuota;
                            fighter1 = f1;
                            fighter2 = f2;
                        }
                    }
                }
            }

            return (fighter1, fighter2);
        }

        private async Task<double> ComputeQuota(Fighter f1, Fighter f2, int tournamentId, List<Fight> pendingFights)
        {
            int ageDifference = Math.Abs(f1.Age - f2.Age);
            int heightDifference = Math.Abs(f1.Height - f2.Height);
            int weightDifference = Math.Abs(f1.Weight - f2.Weight);
            int fightersCount =
                await _fightRepository.SelectCountOfFightsBetweenFightersInTournamentAsync(f1.Id, f2.Id, tournamentId);

            foreach(var fight in pendingFights)
            {
                if ((fight.FighterId1 == f1.Id && fight.FighterId2 == f2.Id)
                    || (fight.FighterId1 == f2.Id && fight.FighterId2 == f1.Id))
                {
                    fightersCount++;
                }
            }

            return 0.05 * ageDifference +
                    0.05 * weightDifference +
                    0.05 * heightDifference +
                    1.85 * fightersCount;
        }
    }
}
