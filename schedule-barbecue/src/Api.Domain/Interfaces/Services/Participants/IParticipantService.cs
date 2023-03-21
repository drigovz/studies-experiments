using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Participants
{
    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> GetAllAsync();
        Task<Participant> GetAsync(int id);
        Task<Participant> PostAsync(Participant category);
        Task<Participant> PutAsync(Participant category);
        Task<bool> DeleteAsync(int id);
    }
}
