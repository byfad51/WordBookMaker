using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace UserSaver.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<WordForDto, Word>().ReverseMap();
        CreateMap<WordResponseForDto, Word>().ReverseMap();

    }
}