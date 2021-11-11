using AutoMapper;
using Core.Contexts;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.MapperConfiguration;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FightClubPlannerTests
{
    public class FighterControllerTest
    {
        private FightClubContext _context;
        private IInviteService _inviteService;
        private ITestService _testService;
        private IFighterService _fighterService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            SetupContext();
            SetupServices();
        }

        [Test]
        public void AnsweredInviteIsUpdated()
        {
            var fighter = _context.Fighter.FirstOrDefault(f => f.FirstName == "Test" && f.LastName == "Fighter");
            var invite = new Invite()
            {
                DateSent = DateTime.Today,
                FighterId = fighter.Id,
                InviteState = InviteState.NotAnswered
            };
            _context.Invite.Add(invite);

            invite.InviteState = InviteState.Accepted;

            _inviteService.AnswerInviteAsync(_mapper.Map<InviteDTO>(invite)).Wait();
            var answeredInvite = _context.Invite.ToList().Last();
            var tournamentFighter = _context.TournamentFighter.ToList().Last();

            Assert.True(answeredInvite.InviteState == InviteState.Accepted && answeredInvite.FighterId == fighter.Id);
            CleanupInvite(answeredInvite);
            CleanupTournamentFighter(tournamentFighter);
            CleanupFighter(fighter);
        }

        [Test]
        public void RegisteredTestIsSaved()
        {
            var fighter = _context.Fighter.FirstOrDefault(f => f.FirstName == "Test" && f.LastName == "Fighter");
            var isolationBubble = new IsolationBubble()
            {
                Name = "Test Isolation Bubble"
            };
            _context.IsolationBubble.Add(isolationBubble);
            _context.SaveChanges();
            isolationBubble = _context.IsolationBubble.ToList().Last();

            var test = new RegisterTestDTO()
            {
                FighterId = fighter.Id,
                IsPositive = true,
                IsolationBubbleId = isolationBubble.Id
            };
            _testService.TestFighterAsync(test).Wait();
            var registeredTest = _context.CovidTest.ToList().Last();

            Assert.True(registeredTest.IsPositive == true && registeredTest.FighterId == fighter.Id);
            CleanupTest(registeredTest);
            CleanupIsolationBubble(isolationBubble);
            CleanupFighter(fighter);
        }

        [Test]
        public void FighterDetailsAreRetrieved()
        {
            var fighter = _context.Fighter.FirstOrDefault(f => f.FirstName == "Test" && f.LastName == "Fighter");
            var tournament = new Tournament()
            {
                Name = "Test Tournament",
                StartDate = DateTime.Today
            };
            _context.Add(tournament);
            _context.SaveChanges();
            tournament = _context.Tournament.ToList().Last();

            var tournamentFighter = new TournamentFighter()
            {
                TournamentId = tournament.Id,
                FighterId = fighter.Id
            };
            _context.TournamentFighter.Add(tournamentFighter);
            _context.SaveChanges();

            var fight = new Fight()
            {
                FighterId1 = fighter.Id,
                WinnerId = fighter.Id,
                TournamentId = tournament.Id,
                FightTime = DateTime.Today
            };
            _context.Fight.Add(fight);
            _context.SaveChanges();

            var isolationBubble = new IsolationBubble()
            {
                Name = "Test Isolation Bubble"
            };
            _context.IsolationBubble.Add(isolationBubble);
            _context.SaveChanges();
            isolationBubble = _context.IsolationBubble.ToList().Last();

            var test = new RegisterTestDTO()
            {
                FighterId = fighter.Id,
                IsPositive = true,
                IsolationBubbleId = isolationBubble.Id
            };
            _testService.TestFighterAsync(test).Wait();
            var registeredTest = _context.CovidTest.ToList().Last();

            var invite = new Invite()
            {
                DateSent = DateTime.Today,
                FighterId = fighter.Id,
                InviteState = InviteState.NotAnswered
            };
            _context.Invite.Add(invite);
            _context.SaveChanges();

            var detailedFighterDTO = _fighterService.GetFighterWithDetailsAsync(fighter.Id).Result;
            Assert.True(detailedFighterDTO.Tournaments.Count == 1 &&
                        detailedFighterDTO.Tournaments[0].Name == "Test Tournament" &&
                        detailedFighterDTO.TestHistory.Count == 2 &&
                        detailedFighterDTO.TestHistory[0].IsolationBubbleName == "Test Isolation Bubble" &&
                        detailedFighterDTO.FightHistory.Count == 1 &&
                        detailedFighterDTO.FightHistory[0].WinnerId == fighter.Id &&
                        detailedFighterDTO.FightHistory[0].FightTime == DateTime.Today);
            CleanupTournamentFighter(tournamentFighter);
            CleanupInvite(invite);
            CleanupTest(registeredTest);
            CleanupIsolationBubble(isolationBubble);
            CleanupFight(fight);
            CleanupTournament(tournament);
            CleanupFighter(fighter);
        }

        [Test]
        public void IsolationBubblesAreRetrieved()
        {
            var fighter = _context.Fighter.FirstOrDefault(f => f.FirstName == "Test" && f.LastName == "Fighter");
            var isolationBubbles = new List<IsolationBubble>();
            for (int i = 0; i < 3; i++)
            {
                isolationBubbles.Add(new IsolationBubble()
                {
                    Name = $"IsolationBubble {i + 1}"
                });
            }

            foreach (var isolationBubble in isolationBubbles)
            {
                _context.IsolationBubble.Add(isolationBubble);
            }
            _context.SaveChanges();

            var retrievedIsolationBubbles = _context.IsolationBubble.ToList();
            var isolationBubblesCount = retrievedIsolationBubbles.Count;

            Assert.True(retrievedIsolationBubbles[isolationBubblesCount - 3].Name == "IsolationBubble 1" &&
                retrievedIsolationBubbles[isolationBubblesCount - 2].Name == "IsolationBubble 2" &&
                retrievedIsolationBubbles[isolationBubblesCount - 1].Name == "IsolationBubble 3");

            CleanupIsolationBubble(retrievedIsolationBubbles[isolationBubblesCount - 3]);
            CleanupIsolationBubble(retrievedIsolationBubbles[isolationBubblesCount - 2]);
            CleanupIsolationBubble(retrievedIsolationBubbles[isolationBubblesCount - 1]);
            CleanupFighter(fighter);
        }

        private void SetupContext()
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

        private void SetupServices()
        {
            var tournamentFighterRepository = new TournamentFighterRepository(_context);
            var inviteRepository = new InviteRepository(_context);
            var covidTestRepository = new CovidTestRepository(_context);
            var fightRepository = new FightRepository(_context);
            var fighterRepository = new FighterRepository(_context, tournamentFighterRepository, fightRepository);
            var isolationBubbleRepository = new IsolationBubbleRepository(_context);
            _mapper = new MapperConfiguration(c => c.AddProfile<MappingProfile>()).CreateMapper();

            _inviteService = new InviteService(inviteRepository, tournamentFighterRepository, _mapper);
            _testService = new TestService(covidTestRepository, fighterRepository, isolationBubbleRepository, _mapper);
            _fighterService = new FighterService(fighterRepository, _mapper);
        }

        private void CleanupFighter(Fighter fighter)
        {
            _context.Fighter.Remove(fighter);
            _context.SaveChanges();
        }

        private void CleanupInvite(Invite invite)
        {
            _context.Invite.Remove(invite);
            _context.SaveChanges();
        }

        private void CleanupTest(CovidTest covidTest)
        {
            _context.CovidTest.Remove(covidTest);
            _context.SaveChanges();
        }

        private void CleanupIsolationBubble(IsolationBubble bubble)
        {
            _context.IsolationBubble.Remove(bubble);
            _context.SaveChanges();
        }

        private void CleanupTournamentFighter(TournamentFighter tournamentFighter)
        {
            _context.TournamentFighter.Remove(tournamentFighter);
            _context.SaveChanges();
        }

        private void CleanupTournament(Tournament tournament)
        {
            _context.Tournament.Remove(tournament);
            _context.SaveChanges();
        }

        private void CleanupFight(Fight fight)
        {
            _context.Fight.Remove(fight);
            _context.SaveChanges();
        }
    }
}
