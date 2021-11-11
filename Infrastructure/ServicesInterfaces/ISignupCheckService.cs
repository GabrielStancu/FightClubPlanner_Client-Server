using Core.Helpers;
using Infrastructure.DTOs;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISignupCheckService
    {
        Task<SignupResult> CheckCredentialsAsync(SignupUserDTO signupUserDTO);
    }
}