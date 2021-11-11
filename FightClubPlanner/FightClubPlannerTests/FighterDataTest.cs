using Core.Contexts;
using Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace FightClubPlannerTests
{
    public class Tests
    {
        private FightClubContext _context;
        [SetUp]
        public void Setup()
        {
            string startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName, "API");
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(startupPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<FightClubContext>()
                .UseSqlServer(new SqlConnection(configuration.GetConnectionString("FightClubConn")))
                .Options;

            _context = new FightClubContext(options);
            _context.Database.EnsureCreated();
            _context.Fighter.Add(new Fighter()
            {
                FirstName = "Test",
                LastName = "Fighter",
                Birthday = DateTime.Today
            });
            _context.SaveChanges();
        }

        [Test]
        public void GivenValidDbReadFightersWorks()
        {
            var fighter = _context.Fighter.FirstOrDefault(f => f.FirstName.Equals("Test")); //and remove if to clear database
            Cleanup(fighter);
            Assert.NotNull(fighter);
        }

        [Test]
        public void GivenValidDbRemoveFighterWorks()
        {
            var fighter = _context.Fighter.FirstOrDefault(f => f.FirstName.Equals("Test"));
            _context.Fighter.Remove(fighter);
            _context.SaveChanges();

            var exists = _context.Fighter.Find(fighter.Id);
            Assert.Null(exists);
        }

        //remove the inserted entity from the database
        private void Cleanup(Fighter fighter)
        {
            _context.Fighter.Remove(fighter);
            _context.SaveChanges();
        }
    }
}