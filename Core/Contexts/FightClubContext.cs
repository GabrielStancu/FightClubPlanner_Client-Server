using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Core.Contexts
{
    public class FightClubContext : DbContext
    {
        public FightClubContext(DbContextOptions<FightClubContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<CovidTest> CovidTest { get; set; }
        public DbSet<Fighter> Fighter { get; set; }
        public DbSet<Fight> Fight { get; set; }
        public DbSet<Invite> Invite { get; set; }
        public DbSet<IsolationBubble> IsolationBubble { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<TournamentFighter> TournamentFighter { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
    }
}
