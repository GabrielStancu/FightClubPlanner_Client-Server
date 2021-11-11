using Core.Helpers;
using System.Collections.Generic;

namespace Infrastructure.DTOs
{
    public class ManagerDTO : UserDTO
    {
        public List<TournamentDTO> Tournaments { get; set; }
    }
}
