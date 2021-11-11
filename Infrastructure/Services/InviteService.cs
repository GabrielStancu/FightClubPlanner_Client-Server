using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InviteService : IInviteService
    {
        private readonly IInviteRepository _inviteRepository;
        private readonly ITournamentFighterRepository _tournamentFighterRepository;
        private readonly IMapper _mapper;

        public InviteService(IInviteRepository inviteRepository,
            ITournamentFighterRepository tournamentFighterRepository, IMapper mapper)
        {
            _inviteRepository = inviteRepository;
            _tournamentFighterRepository = tournamentFighterRepository;
            _mapper = mapper;
        }
        public async Task AnswerInviteAsync(InviteDTO inviteDTO)
        {
            await _inviteRepository.UpdateAsync(_mapper.Map<InviteDTO, Invite>(inviteDTO));

            if (inviteDTO.InviteState == InviteState.Accepted)
            {
                var tf = new TournamentFighter()
                {
                    TournamentId = inviteDTO.TournamentId,
                    FighterId = inviteDTO.FighterId
                };
                await _tournamentFighterRepository.InsertAsync(tf);
            }
        }

        public async Task SendInviteAsync(InviteDTO inviteDTO)
        {
            await _inviteRepository.InsertAsync(_mapper.Map<InviteDTO, Invite>(inviteDTO));
        }
    }
}
