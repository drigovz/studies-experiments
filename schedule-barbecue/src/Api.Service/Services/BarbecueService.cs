using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services.BarbecueService;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class BarbecueService : IBarbecueService
    {
        private readonly IBarbecueRepository _repository;
        private readonly IMapper _mapper;

        public BarbecueService(IBarbecueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private async Task<decimal> TotalValueParticipants(int barbecueId)
        {
            decimal totalValue = 0;
            var participants = await BarbecueParticipants(barbecueId);
            if (participants != null)
            {
                foreach (Participant item in participants)
                {
                    totalValue += item.ContribuitionValue;
                }
            }

            return totalValue;
        }

        public async Task<IEnumerable<BarbecueDTO>> GetAllAsync()
        {
            var barbecues = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<BarbecueDTO>>(barbecues);
        }

        public async Task<BarbecueDetailsDTO> GetAsync(int id)
        {
            var barbecue = await _repository.GetByIdAsync(id);
            var barbecueDTO = _mapper.Map<BarbecueDetailsDTO>(barbecue);
            var participants = await BarbecueParticipants(id);

            var participantsDTO = _mapper.Map<IEnumerable<ParticipantDTO>>(participants.ToList());
            barbecueDTO.Participants = participantsDTO.ToList();
            barbecueDTO.TotalValue = await TotalValueParticipants(id);
            barbecueDTO.TotalParticipants = participants.ToList().Count();

            return barbecueDTO;
        }

        public async Task<BarbecueDTO> PostAsync(BarbecueDTO barbecue)
        {
            var entity = _mapper.Map<Barbecue>(barbecue);
            var result = await _repository.AddAsync(entity);

            return _mapper.Map<BarbecueDTO>(result);
        }

        public async Task<BarbecueDTO> PutAsync(BarbecueDTO barbecue)
        {
            var entity = _mapper.Map<Barbecue>(barbecue);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<BarbecueDTO>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Participant>> BarbecueParticipants(int barbecueId)
        {
            return await _repository.BarbecueParticipants(barbecueId);
        }

        public async Task<ParticipantDTO> AddParticipantsOnBarbecue(ParticipantDTO participant)
        {
            var entity = _mapper.Map<Participant>(participant);
            var result = await _repository.AddParticipantsOnBarbecue(entity);

            return _mapper.Map<ParticipantDTO>(result);
        }

        public async Task<bool> RemoveParticipantsFromBarbecue(int participantId)
        {
            return await _repository.RemoveParticipantsFromBarbecue(participantId);
        }
    }
}
