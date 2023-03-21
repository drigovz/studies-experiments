using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCleanArch.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [MinLength(6)]
        public string Description { get; set; }

        [MinLength(1, ErrorMessage = "Invalid price value!")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [MinLength(1, ErrorMessage = "Invalid stock value!")]
        [Range(1, 9999)]
        public int Stock { get; set; }

        [MaxLength(250, ErrorMessage = "Invalid image name, too long, maximum 250 characters!")]
        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}
