using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Code { get; set;}

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Vat { get; set; } = "20";
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? OnStock { get; set; }
        public string? Manufacturer { get; set; }

        public Product(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
