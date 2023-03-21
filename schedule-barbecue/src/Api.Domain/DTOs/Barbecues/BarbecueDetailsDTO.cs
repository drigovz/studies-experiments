using Api.Domain.DTOs.Participants;
using System;
using System.Collections.Generic;

namespace Api.Domain.DTOs.Barbecues
{
    public class BarbecueDetailsDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string AdditionalNotes { get; set; }
        public List<ParticipantDTO> Participants { get; set; } = new List<ParticipantDTO>();
        public int TotalParticipants { get; set; }
        public decimal TotalValue { get; set; }
    }
}
