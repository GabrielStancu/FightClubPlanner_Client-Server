using System;
using System.Collections.Generic;

namespace Infrastructure.DTOs
{
    public class DetailedTournamentDTO
    {
        public int Id { get; set; }
        public List<FighterDTO> Fighters { get; set; }
        public List<FightDTO> Fights { get; set; }
        public DateTime StartDate { get; set; }
    }
}
