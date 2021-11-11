using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IFightRepository _fightRepository;
        private readonly IMapper _mapper;

        public TournamentService(ITournamentRepository tournamentRepository, 
            IFightRepository fightRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _fightRepository = fightRepository;
            _mapper = mapper;
        }

        public async Task<DetailedTournamentDTO> GetTournamentInfoAsync(int id)
        {
            var tournament = await _tournamentRepository.SelectTournamentWithDetailsByIdAsync(id);
            return _mapper.Map<Tournament, DetailedTournamentDTO>(tournament);
        }
        public async Task<bool> AddTournamentAsync(AddTournamentDTO addTournamentDTO)
        {
            if (ValidCredentials(addTournamentDTO))
            {
                bool takenName = await _tournamentRepository.TournamentNameTaken(addTournamentDTO.Name);
                if (takenName)
                {
                    return false;
                }

                await _tournamentRepository.InsertAsync(_mapper.Map<AddTournamentDTO, Tournament>(addTournamentDTO));
                return true;
            }

            return false;
        }

        public async Task SetFightWinnerAsync(FightDTO fightDTO)
        {
            await _fightRepository.UpdateAsync(_mapper.Map<FightDTO, Fight>(fightDTO));
        }

        private bool ValidCredentials(AddTournamentDTO addTournamentDTO)
        {
            if (addTournamentDTO.Name is null ||
                addTournamentDTO.Location is null ||
                addTournamentDTO.StartDate < DateTime.Today)
            {
                return false;
            }

            return true;
        }
    }
}
