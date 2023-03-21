using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra.Data.Implementations
{
    public class BarbecueImplementation : BaseRepository<Barbecue>, IBarbecueRepository
    {
        private readonly DbSet<Barbecue> _dataset;

        public BarbecueImplementation(AppDbContext context)
            : base(context)
        {
            _dataset = context.Set<Barbecue>();
        }

        private async Task<IEnumerable<Participant>> Participants(int barbecueId)
        {
            var participants = await _context.Set<Participant>().Where(x => x.BarbecueId == barbecueId).ToListAsync();
            return participants;
        }

        public async Task<IEnumerable<Participant>> BarbecueParticipants(int barbecueId)
        {
            return await Participants(barbecueId);
        }

        public async Task<Participant> AddParticipantsOnBarbecue(Participant participant)
        {
            try
            {
                participant.CreatedAt = DateTime.UtcNow;

                _context.Set<Participant>().Add(participant);
                await Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return participant;
        }

        public async Task<bool> RemoveParticipantsFromBarbecue(int participantId)
        {
            try
            {
                var result = await _context.Set<Participant>().FirstOrDefaultAsync(x => x.Id == participantId);
                if (result == null)
                    return false;

                _context.Set<Participant>().Remove(result);
                await Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
