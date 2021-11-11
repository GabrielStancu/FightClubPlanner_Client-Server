using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ICovidTestRepository : IGenericRepository<CovidTest>
    {
        Task<List<CovidTest>> SelectCovidTestsForFighterAsync(int id);
    }
}