using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Repository
{
    public interface IBarbecueRepository : IRepository<Barbecue>
    {
        Task<IEnumerable<Participant>> BarbecueParticipants(int barbecueId);
        Task<Participant> AddParticipantsOnBarbecue(Participant participant);
        Task<bool> RemoveParticipantsFromBarbecue(int participantId);
    }
}
