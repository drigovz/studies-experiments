using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.Participants
{
    public class ParticipantDTO
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contribuition value is required!")]
        public decimal ContribuitionValue { get; set; }

        [Required(ErrorMessage = "The value barbecueId not valid!")]
        public int BarbecueId { get; set; }

        public decimal SugestedValue { get; set; }

        public decimal SugestedValueWithDink { get; set; }
    }
}
