using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Fight : BaseModel
    {
        [ForeignKey("Fighter1")]
        public int FighterId1 { get; set; }
        [NotMapped]
        public Fighter Fighter1 { get; set; }
        [ForeignKey("Fighter2")]
        public int FighterId2 { get; set; }
        [NotMapped]
        public Fighter Fighter2 { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public DateTime FightTime { get; set; }
        [ForeignKey("Winner")]
        public int? WinnerId { get; set; }
#nullable enable
        public Fighter? Winner { get; set; }
        [NotMapped]
        public bool IsWinnerSet { get => Winner != null; }
    }
}
