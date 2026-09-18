// GolBet.Services/Mapping/MappingProfile.cs
using AutoMapper;
using GolBet.Entities;
using GolBet.Services.DTOs;

namespace GolBet.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Flattening by convention:
        // MatchDto.HomeTeamName  <- Match.HomeTeam.Name
        // MatchDto.AwayTeamCrestUrl <- Match.AwayTeam.CrestUrl
        CreateMap<Match, MatchDto>();

        // GolBet.Services/Mapping/MappingProfile.cs  (agregar dentro del constructor)
        CreateMap<Match, MatchDetailDto>()
            .ForMember(dto => dto.TotalBets,   // DESTINO
                       options => options.MapFrom(match => match.Bets.Count));   // ORIGEN
    }
}