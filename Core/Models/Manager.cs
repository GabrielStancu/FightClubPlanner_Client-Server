using System.Collections.Generic;

namespace Core.Models
{
    public class Manager : User
    {
        public List<Tournament> Tournaments { get; set; }
    }
}
