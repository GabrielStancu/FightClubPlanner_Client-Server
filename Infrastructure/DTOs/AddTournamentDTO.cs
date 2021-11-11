using System;

namespace Infrastructure.DTOs
{
    public class AddTournamentDTO
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int OrganizerId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
