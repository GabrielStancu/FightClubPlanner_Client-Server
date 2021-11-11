using Infrastructure.DTOs;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IInviteService
    {
        Task AnswerInviteAsync(InviteDTO inviteDTO);
        Task SendInviteAsync(InviteDTO inviteDTO);
    }
}