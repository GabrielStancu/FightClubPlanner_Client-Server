using Core.Models;
using Infrastructure.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ITestService
    {
        Task<List<CovidTestDTO>> TestFighterAsync(RegisterTestDTO registerTestDTO);
        Task<IReadOnlyList<IsolationBubble>> GetIsolationBubblesAsync();
    }
}