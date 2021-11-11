using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Services;
using Infrastructure.TournamentStrategies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        private readonly IInviteService _inviteService;
        private readonly IInvitableFightersSelectService _invitableFightersSelectService;
        private readonly IFightsGenerateService _fightsGenerateService;
        private readonly IManagerService _managerService;

        public ManagerController(ITournamentService tournamentService, IInviteService inviteService,
            IInvitableFightersSelectService invitableFightersSelectService, IFightsGenerateService fightsGenerateService,
            IManagerService managerService)
        {
            _tournamentService = tournamentService;
            _inviteService = inviteService;
            _invitableFightersSelectService = invitableFightersSelectService;
            _fightsGenerateService = fightsGenerateService;
            _managerService = managerService;
        }

        [HttpPost("tournaments")]
        public async Task<ActionResult<bool>> AddTournament(AddTournamentDTO addTournamentDTO)
        {
            var added = await _tournamentService.AddTournamentAsync(addTournamentDTO);
            return Ok(added);
        }

        [HttpGet("tournaments/{id}")]
        public async Task<ActionResult<IReadOnlyList<TournamentDTO>>> GetTournamentsForManager(int id)
        {
            var tournaments = await _managerService.SelectTournamentsForManagerAsync(id);
            return Ok(tournaments);
        }

        [HttpGet("tournamentdetails/{id}")]
        public async Task<ActionResult<DetailedTournamentDTO>> GetTournamentInfo(int id)
        {
            var tournament = await _tournamentService.GetTournamentInfoAsync(id);
            return Ok(tournament);
        }

        [HttpGet("invitableFighters/{id}")]
        public async Task<ActionResult<IReadOnlyList<Fighter>>> GetInvitableFighters(int id)
        {
            var invitableFighters = await _invitableFightersSelectService.SelectInvitableFightersAsync(id);
            return Ok(invitableFighters);
        }

        [HttpPost("invites")]
        public async Task<ActionResult<bool>> SendInvite(InviteDTO inviteDTO)
        {
            await _inviteService.SendInviteAsync(inviteDTO);
            return Ok(true);
        }

        [HttpGet("weeklyfights/{tournamentId}")]
        public async Task<ActionResult<bool>> GenerateWeeklyFights(int tournamentId)
        {
            var generatedFights = await _fightsGenerateService.GenerateFightsAsync(new WeeklyMatchStrategy(), tournamentId);
            return Ok(generatedFights);
        }

        [HttpGet("monthlyfights/{tournamentId}")]
        public async Task<ActionResult<bool>> GenerateMonthlyFights(int tournamentId)
        {
            bool added = await _fightsGenerateService.GenerateFightsAsync(new MonthlyMatchStrategy(), tournamentId);
            return Ok(added);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> SetFightWinner(FightDTO fightDTO)
        {
            await _tournamentService.SetFightWinnerAsync(fightDTO);
            return Ok(true);
        }

        [HttpGet("reschedule/{tournamentId}")]
        public async Task<ActionResult<bool>> RescheduleFights(int tournamentId)
        {
            var rescheduled = await _fightsGenerateService.RescheduleFights(tournamentId);
            return Ok(rescheduled);
        }
    }
}
