using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InvitableFightersSelectService : IInvitableFightersSelectService
    {
        private readonly IInviteRepository _inviteRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;

        public InvitableFightersSelectService(IInviteRepository inviteRepository, 
            IFighterRepository fighterRepository, IMapper mapper)
        {
            _inviteRepository = inviteRepository;
            _fighterRepository = fighterRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<FighterDTO>> SelectInvitableFightersAsync(int tournamentId)
        {
            var tournamentInvites = await _inviteRepository.SelectAllInvitesByTournamentIdAsync(tournamentId);
            var invitedFighters = GetInvitedFighters(tournamentInvites);
            var allFighters = await _fighterRepository.SelectAllFightersAsync();

            return GetInvitableFighters(allFighters, invitedFighters);
        }

        private List<Fighter> GetInvitedFighters(List<Invite> tournamentInvites)
        {
            var invitedFighters = new List<Fighter>();

            tournamentInvites.ForEach(ti =>
            {
                invitedFighters.Add(ti.Fighter);
            });

            return invitedFighters;
        }

        private List<FighterDTO> GetInvitableFighters(List<Fighter> allFighters, List<Fighter> invitedFighters)
        {
            var invitableFighters = new List<Fighter>();
            foreach (var fighter in allFighters)
            {
                bool invited = false;

                foreach (var invitedFighter in invitedFighters)
                {
                    if (invitedFighter.Id == fighter.Id)
                    {
                        invited = true;
                        break;
                    }
                }

                if (!invited)
                {
                    invitableFighters.Add(fighter);
                }
            }

            var invitableFightersDTO = new List<FighterDTO>();
            invitableFighters.ForEach(f => invitableFightersDTO.Add(_mapper.Map<Fighter, FighterDTO>(f)));
            return invitableFightersDTO;
        }
    }
}
