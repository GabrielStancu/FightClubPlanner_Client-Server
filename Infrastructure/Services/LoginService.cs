using Core.Helpers;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LoginService : ILoginService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IFighterRepository _fighterRepository;

        public LoginService(IManagerRepository managerRepository, IFighterRepository fighterRepository)
        {
            _managerRepository = managerRepository;
            _fighterRepository = fighterRepository;
        }
        public async Task<LoginResultDTO> LoginAsync(string username, string password)
        {
            var managerId =
                await _managerRepository.SelectUserWithLoginInformationAsync(username, password);

            if (managerId > 0)
            {
                return new LoginResultDTO() { LoginSuccess = true, UserId = managerId, UserType = UserType.Manager };
            }

            var fighterId =
                    await _fighterRepository.SelectUserWithLoginInformationAsync(username, password);

            if (fighterId > 0)
            {
                return new LoginResultDTO() { LoginSuccess = true, UserId = fighterId, UserType = UserType.Fighter };
            }

            return new LoginResultDTO() { LoginSuccess = false, UserId = 0, UserType = UserType.NotRegistered };
        }
    }
}
