using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IIsolationBubbleRepository : IGenericRepository<IsolationBubble>
    {
        Task<bool> CheckIfBubbleAlreadyExistsAsync(string name);
        Task<List<IsolationBubble>> SelectAllIsolationBubblesAsync();
    }
}