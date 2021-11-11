using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Core.Models
{
    public class Fighter : User
    {
        [NotMapped]
        public List<Fight> FightHistory { get; set; }
        public List<CovidTest> TestHistory { get; set; }
        public DateTime Birthday { get; set; }
        [NotMapped]
        public int Age { get => (DateTime.Today - Birthday).Days / 365; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public List<TournamentFighter> TournamentFighters { get; set; }
        [NotMapped]
        public bool IsEligible { get; set; }
        [NotMapped]
        public List<Tournament> Tournaments { get; set; }
        public List<Invite> Invites { get; set; }

        public bool CanFight(DateTime fightDate)
        {
            if (TestHistory is null)
            {
                return false;
            }

            Func<CovidTest, bool> testsTwoWeeksAgo = t => (fightDate - t.TestDate).Days < 21 && (fightDate - t.TestDate).Days >= 14;
            Func<CovidTest, bool> testsOneWeekAgo = t => (fightDate - t.TestDate).Days < 14 && (fightDate - t.TestDate).Days >= 7;
            Func<CovidTest, bool> testsThisWeek = t => (fightDate - t.TestDate).Days < 7 && (fightDate - t.TestDate).Days >= 0;

            return TestHistory.Count > 0 &&
                    TestHistory.Any(testsTwoWeeksAgo) &&
                    TestHistory.Any(testsOneWeekAgo) &&
                    TestHistory.Any(testsThisWeek) &&
                    TestHistory.Where(testsTwoWeeksAgo).All(t => t.IsPositive == false) &&
                    TestHistory.Where(testsOneWeekAgo).All(t => t.IsPositive == false) &&
                    TestHistory.Where(testsThisWeek).All(t => t.IsPositive == false);
        }

        public void SetTournaments()
        {
            Tournaments = new List<Tournament>();
            TournamentFighters.ForEach(tf => Tournaments.Add(tf.Tournament));
        }
    }
}
