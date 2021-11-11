using Core.Models;
using System;
using System.Linq;

namespace Infrastructure.TournamentStrategies
{
    public interface IMatchStrategy
    {
        Fight Execute(Tournament tournament, Fighter fighter1, Fighter fighter2);

        public DateTime GetLastMatchDate(Tournament tournament)
        {
            if (tournament.Fights.Count == 0)
            {
                return tournament.StartDate > DateTime.Today ? tournament.StartDate : DateTime.Today;
            }

            var lastDate = tournament.Fights.Max(f => f.FightTime);
            return lastDate;
        }
    }
}
