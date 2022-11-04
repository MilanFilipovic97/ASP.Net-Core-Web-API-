using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Dtos
{
    public class ProductDtoForCreation
    {
        //[Key]
        //public int Id { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Vat { get; set; } = "20";
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? OnStock { get; set; }
        public string? Manufacturer { get; set; }

    }
}
