using Core.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CovidTestRepository : GenericRepository<CovidTest>, ICovidTestRepository
    {
        public CovidTestRepository(FightClubContext context) : base(context) { }

        public async Task<List<CovidTest>> SelectCovidTestsForFighterAsync(int id)
        {
            return await
                Context.CovidTest
                    .Include(c => c.IsolationBubble)
                    .Where(c => c.FighterId == id)
                    .ToListAsync();
        }
    }
}
