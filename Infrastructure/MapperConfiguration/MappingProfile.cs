using AutoMapper;
using Core.Models;
using Infrastructure.DTOs;

namespace Infrastructure.MapperConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Manager, ManagerDTO>();
            CreateMap<Fighter, FighterDTO>();
            CreateMap<LoginUserDTO, User>();
            CreateMap<SignupUserDTO, Manager>();
            CreateMap<SignupUserDTO, Fighter>();
            CreateMap<AddTournamentDTO, Tournament>();
            CreateMap<Tournament, TournamentDTO>();
            CreateMap<Tournament, DetailedTournamentDTO>();
            CreateMap<InviteDTO, Invite>();
            CreateMap<FightDTO, Fight>();
            CreateMap<InviteAnswered, Invite>();

            CreateMap<CovidTest, CovidTestDTO>()
                .ForMember(dest => dest.IsolationBubbleName,
                map => map.MapFrom(
                    src => src.IsolationBubble.Name
                    ));

            CreateMap<Invite, InviteDTO>()
                .ForMember(dest => dest.TournamentName,
                map => map.MapFrom(
                    src => src.Tournament.Name
                    ));

            CreateMap<Fight, FightDTO>()
                .ForMember(dest => dest.FighterName1,
                map => map.MapFrom(
                    src => src.Fighter1.FullName
                    ))
                .ForMember(dest => dest.FighterName2,
                map => map.MapFrom(
                    src => src.Fighter2.FullName
                    ))
                .ForMember(dest => dest.WinnerName,
                map => map.MapFrom(
                    src => src.Winner.FullName
                    ))
                .ForMember(dest => dest.TournamentName,
                map => map.MapFrom(
                    src => src.Tournament.Name
                    ));

            CreateMap<Fighter, DetailedFighterDTO>();             
        }
    }
}
