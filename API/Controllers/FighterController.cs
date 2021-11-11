using API.EventHandlers;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FighterController : ControllerBase
    {
        private readonly IFighterService _fighterService;
        private readonly ITestService _testService;
        private readonly IInviteService _inviteService;
        private readonly Mediator _mediator;

        public FighterController(
            IFighterService fighterService,
            ITestService testService, 
            IInviteService inviteService,
            Mediator mediator)
        {
            _fighterService = fighterService;
            _testService = testService;
            _inviteService = inviteService;
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<ActionResult> AnswerInvite(InviteAnswered request)
        {
            await _mediator.Handle(request);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<IReadOnlyList<CovidTestDTO>>> RegisterTest(RegisterTestDTO registerTestDTO)
        {
            var tests = await _testService.TestFighterAsync(registerTestDTO);    
            return Ok(tests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailedFighterDTO>> GetFighterDetails(int id)
        {
            var fighter = await _fighterService.GetFighterWithDetailsAsync(id);
            return Ok(fighter);
        }

        [HttpGet("isolationBubbles")]
        public async Task<ActionResult<IReadOnlyList<IsolationBubble>>> GetIsolationBubbles()
        {
            var isolationBubbles = await _testService.GetIsolationBubblesAsync();
            return Ok(isolationBubbles);
        }
    }
}
