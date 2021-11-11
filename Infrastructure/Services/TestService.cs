using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TestService : ITestService
    {
        private readonly ICovidTestRepository _covidTestRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly IIsolationBubbleRepository _isolationBubbleRepository;
        private readonly IMapper _mapper;

        public TestService(ICovidTestRepository covidTestRepository, IFighterRepository fighterRepository,
            IIsolationBubbleRepository isolationBubbleRepository, IMapper mapper)
        {
            _covidTestRepository = covidTestRepository;
            _fighterRepository = fighterRepository;
            _isolationBubbleRepository = isolationBubbleRepository;
            _mapper = mapper;
        }

        public async Task<List<CovidTestDTO>> TestFighterAsync(RegisterTestDTO registerTestDTO)
        {
            var fighter = await _fighterRepository.SelectFighterWithTestsHistoryAsync(registerTestDTO.FighterId);
            var isolationBubble = await _isolationBubbleRepository.SelectByIdAsync(registerTestDTO.IsolationBubbleId);
            var fighterTests = await _covidTestRepository.SelectCovidTestsForFighterAsync(registerTestDTO.FighterId);
            var tests = new List<CovidTest>();
            var mappedTests = new List<CovidTestDTO>();

            CovidTest ownTest, bubbleTest;
            bubbleTest = await RegisterTestBubbleTest(fighter, isolationBubble);

            if (fighterTests.Count == 0)
            {
                ownTest = await RegisterOwnTest(fighter, isolationBubble, registerTestDTO.IsPositive);
                tests.Add(ownTest);
            }

            tests.Add(bubbleTest);
            tests.ForEach(t => mappedTests.Add(_mapper.Map<CovidTest, CovidTestDTO>(t)));

            return mappedTests;
        }

        public async Task<IReadOnlyList<IsolationBubble>> GetIsolationBubblesAsync()
        {
            var isolationBubbles = await _isolationBubbleRepository.SelectAllIsolationBubblesAsync();
            return isolationBubbles;
        }

        private async Task<CovidTest> RegisterOwnTest(Fighter fighter, IsolationBubble isolationBubble, bool isPositive)
        {
            CovidTest fighterTest = new CovidTest()
            {
                FighterId = fighter.Id,
                IsPositive = isPositive,
                IsolationBubbleId = isolationBubble.Id,
                TestDate = DateTime.Today
            };
            await _covidTestRepository.InsertAsync(fighterTest);

            fighterTest.IsolationBubble = isolationBubble;

            return fighterTest;
        }

        private async Task<CovidTest> RegisterTestBubbleTest(Fighter fighter, IsolationBubble isolationBubble)
        {
            CovidTest onTheSpotTest = new CovidTest()
            {
                FighterId = fighter.Id,
                IsPositive = new Random().Next(0, 100) >= 90,
                IsolationBubbleId = isolationBubble.Id,
                TestDate = DateTime.Today
            };
            await _covidTestRepository.InsertAsync(onTheSpotTest);

            onTheSpotTest.IsolationBubble = isolationBubble;

            return onTheSpotTest;
        }
    }
}
