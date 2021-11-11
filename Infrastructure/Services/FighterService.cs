using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FighterService : IFighterService
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;

        public FighterService(IFighterRepository fighterRepository, IMapper mapper)
        {
            _fighterRepository = fighterRepository;
            _mapper = mapper;
        }
        public async Task<DetailedFighterDTO> GetFighterWithDetailsAsync(int id)
        {
            var fighter = await _fighterRepository.SelectFighterWithDataAsync(id);
            return _mapper.Map<Fighter, DetailedFighterDTO>(fighter);
        }
    }
}
