using System.ComponentModel.DataAnnotations;

namespace ProductsCleanArch.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(3, ErrorMessage = "Name need more than 2 chars!")]
        public string Name { get; set; }
    }
}
