using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.BarbecueService
{
    public interface IBarbecueService
    {
        Task<IEnumerable<BarbecueDTO>> GetAllAsync();
        Task<BarbecueDetailsDTO> GetAsync(int id);
        Task<BarbecueDTO> PostAsync(BarbecueDTO barbecue);
        Task<BarbecueDTO> PutAsync(BarbecueDTO barbecue);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Participant>> BarbecueParticipants(int barbecueId);
        Task<ParticipantDTO> AddParticipantsOnBarbecue(ParticipantDTO participant);
        Task<bool> RemoveParticipantsFromBarbecue(int participantId);
    }
}
