using Core.Models;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.TournamentStrategies
{
    public class TournamentScheduler : ITournamentScheduler
    {
        private readonly IFightRepository _fightRepository;
        private readonly IMatchGenerator _matchGenerator;
        private readonly List<Fight> _fights;

        public TournamentScheduler(IMatchGenerator matchGenerator, IFightRepository fightRepository)
        {
            _fightRepository = fightRepository;
            _fights = new List<Fight>();
            _matchGenerator = matchGenerator;
        }

        public async Task<bool> AddFight(IMatchStrategy strategy, Tournament tournament)
        {
            var (fighter1, fighter2) = await _matchGenerator.GetBestMatch(tournament.Id, _fights);

            if (fighter1.Id == 0 || fighter2.Id == 0)
            {
                return false;
            }

            var fight = strategy.Execute(tournament, fighter1, fighter2);
            _fights.Add(fight);
            return true;
        }

        public async Task<Tournament> Build(Tournament tournament)
        {
            foreach (var fight in _fights)
            {
                await _fightRepository.InsertAsync(fight);
            }
            tournament.Fights.AddRange(_fights);

            return tournament;
        }
    }
}
