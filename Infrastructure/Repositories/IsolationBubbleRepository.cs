using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class IsolationBubbleRepository : GenericRepository<IsolationBubble>, IIsolationBubbleRepository
    {
        public IsolationBubbleRepository(FightClubContext context) : base(context) { }

        public async Task<List<IsolationBubble>> SelectAllIsolationBubblesAsync()
        {
            return await
                Context.IsolationBubble
                    .ToListAsync();
        }

        public async Task<bool> CheckIfBubbleAlreadyExistsAsync(string name)
        {
            var bubbles = await
                Context.IsolationBubble
                    .Where(ib => ib.Name.Equals(name))
                    .ToListAsync();
            return bubbles.Count > 0;
        }
    }
}
