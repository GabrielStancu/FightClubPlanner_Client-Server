using System.Collections.Generic;

namespace Core.Models
{
    public class IsolationBubble : BaseModel
    {
        public List<CovidTest> CovidTests { get; set; }
        public string Name { get; set; }
    }
}
