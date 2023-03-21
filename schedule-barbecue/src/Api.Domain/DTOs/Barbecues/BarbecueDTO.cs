using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs.Barbecues
{
    public class BarbecueDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required!")]
        //[DataType(DataType.Date, ErrorMessage = "Date format not valid!")]
        //[MinLength(8, ErrorMessage = "Date format not accept!")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [MinLength(2, ErrorMessage = "The description length must contain more than two characters!")]
        public string Description { get; set; }

        public string AdditionalNotes { get; set; }
    }
}
