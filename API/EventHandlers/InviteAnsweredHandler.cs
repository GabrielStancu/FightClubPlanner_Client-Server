using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class InviteAnsweredHandler : IEventHandler<InviteAnswered>
    {
        private readonly IMapper _mapper;
        private readonly IInviteRepository _inviteRepository;
        private readonly ITournamentFighterRepository _tournamentFighterRepository;

        public InviteAnsweredHandler(
            IMapper mapper,
            IInviteRepository inviteRepository,
            ITournamentFighterRepository tournamentFighterRepository)
        {
            _mapper = mapper;
            _inviteRepository = inviteRepository;
            _tournamentFighterRepository = tournamentFighterRepository;
        }
        public async Task HandleRequestAsync(InviteAnswered request)
        {
            await _inviteRepository.UpdateAsync(_mapper.Map<InviteAnswered, Invite>(request));

            if (request.InviteState == InviteState.Accepted)
            {
                var tf = new TournamentFighter()
                {
                    TournamentId = request.TournamentId,
                    FighterId = request.FighterId
                };
                await _tournamentFighterRepository.InsertAsync(tf);
            }
        }
    }
}
