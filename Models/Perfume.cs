using System.ComponentModel.DataAnnotations;

namespace Perfumeria.Models
{
    public class Perfume
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Brand { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl {get; set;} = string.Empty;
        public int Stock { get; set; }
    }
}
