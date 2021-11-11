using AutoMapper;
using Core.Helpers;
using Core.Models;
using Infrastructure.DTOs;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SignupCheckService : ISignupCheckService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;

        public SignupCheckService(IManagerRepository managerRepository,
            IFighterRepository fighterRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _fighterRepository = fighterRepository;
            _mapper = mapper;
        }
        public async Task<SignupResult> CheckCredentialsAsync(SignupUserDTO signupUserDTO)
        {
            bool existsManager =
            await _managerRepository.CheckAlreadyRegisteredUserAsync(signupUserDTO.Username);

            bool existsFighter =
                await _fighterRepository.CheckAlreadyRegisteredUserAsync(signupUserDTO.Username);

            if (!existsManager && !existsFighter)
            {
                if (signupUserDTO.UserType == UserType.Manager)
                {
                    return await CheckManager(signupUserDTO);
                }
                else
                {
                    return await CheckFighter(signupUserDTO);
                }
            }
            else
            {
                return SignupResult.UserAlreadyRegistered;
            }
        }

        private async Task<SignupResult> CheckManager(SignupUserDTO signupUserDTO)
        {
            if (!AllManagerFieldsValid(signupUserDTO))
            {
                return SignupResult.BadCredentials;
            }

            await _managerRepository.RegisterUserAsync(_mapper.Map<SignupUserDTO, Manager>(signupUserDTO));
            return SignupResult.Registered;
        }

        private async Task<SignupResult> CheckFighter(SignupUserDTO signupUserDTO)
        {
            if (!AllFighterFieldsValid(signupUserDTO))
            {
                return SignupResult.BadCredentials;
            }

            await _fighterRepository.RegisterUserAsync(_mapper.Map<SignupUserDTO, Fighter>(signupUserDTO));
            return SignupResult.Registered;
        }

        private bool AllManagerFieldsValid(SignupUserDTO signupUserDTO)
        {
            return !(signupUserDTO.Username is null ||
                    signupUserDTO.Password is null ||
                    signupUserDTO.RepeatedPassword is null ||
                    signupUserDTO.FirstName is null ||
                    signupUserDTO.LastName is null ||
                    !signupUserDTO.Password.Equals(signupUserDTO.RepeatedPassword));
        }

        private bool AllFighterFieldsValid(SignupUserDTO signupUserDTO)
        {
            return !(signupUserDTO.Username is null ||
                    signupUserDTO.Password is null ||
                    signupUserDTO.RepeatedPassword is null ||
                    signupUserDTO.FirstName is null ||
                    signupUserDTO.LastName is null ||
                    !signupUserDTO.Password.Equals(signupUserDTO.RepeatedPassword) ||
                    signupUserDTO.Weight < 40 ||
                    signupUserDTO.Weight > 150 ||
                    signupUserDTO.Height < 120 ||
                    signupUserDTO.Height > 250 ||
                    (DateTime.Today - signupUserDTO.Birthday).Days / 365 < 18
                    );
        }
    }
}
