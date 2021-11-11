using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public ManagerService(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<TournamentDTO>> SelectTournamentsForManagerAsync(int id)
        {
            var tournaments = await _tournamentRepository.SelectTournamentsByManagerIdAsync(id);
            var mappedTournaments = new List<TournamentDTO>();
            tournaments.ForEach(t => mappedTournaments.Add(_mapper.Map<Tournament, TournamentDTO>(t)));
            return mappedTournaments;
        }
    }
}
