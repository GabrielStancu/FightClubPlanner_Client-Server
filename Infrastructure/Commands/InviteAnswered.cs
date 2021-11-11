using Core.Models;
using System;

namespace Infrastructure.DTOs
{
    public class InviteAnswered
    {
        public int Id { get; set; }
        public int FighterId { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public string TournamentLocation { get; set; }
        public DateTime DateSent { get; set; }
        public InviteState InviteState { get; set; }
    }
}
