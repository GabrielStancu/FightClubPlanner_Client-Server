using Core.Models;
using System;

namespace Infrastructure.TournamentStrategies
{
    public class WeeklyMatchStrategy : IMatchStrategy
    {
        private DateTime _nextMatchDate;
        public Fight Execute(Tournament tournament, Fighter fighter1, Fighter fighter2)
        {
            if (_nextMatchDate == DateTime.MinValue)
            {
                _nextMatchDate = ((IMatchStrategy)this).GetLastMatchDate(tournament);

                if (_nextMatchDate < DateTime.Today)
                {
                    _nextMatchDate = DateTime.Today;
                }
            }

            _nextMatchDate = _nextMatchDate.AddDays(3);

            var fight = new Fight()
            {
                FighterId1 = fighter1.Id,
                FighterId2 = fighter2.Id,
                TournamentId = tournament.Id,
                FightTime = _nextMatchDate
            };

            return fight;
        }
    }
}
