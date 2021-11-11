using System;

namespace Infrastructure.DTOs
{
    public class CovidTestDTO
    {
        public int Id { get; set; }
        public bool IsPositive { get; set; }
        public DateTime TestDate { get; set; }
        public int FighterId { get; set; }
        public int IsolationBubbleId { get; set; }
        public string IsolationBubbleName { get; set; }
    }
}
