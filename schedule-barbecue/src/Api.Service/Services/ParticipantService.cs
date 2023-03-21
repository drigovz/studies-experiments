using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Participants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IRepository<Participant> _repository;

        public ParticipantService(IRepository<Participant> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Participant>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Participant> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Participant> PostAsync(Participant participant)
        {
            return await _repository.AddAsync(participant);
        }

        public async Task<Participant> PutAsync(Participant participant)
        {
            return await _repository.UpdateAsync(participant);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
