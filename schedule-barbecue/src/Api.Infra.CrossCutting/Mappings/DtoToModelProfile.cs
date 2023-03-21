using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.Infra.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<Barbecue, BarbecueDTO>().ReverseMap();
            CreateMap<Barbecue, BarbecueDetailsDTO>().ReverseMap();
            CreateMap<Participant, ParticipantDTO>().ReverseMap();
        }
    }
}
