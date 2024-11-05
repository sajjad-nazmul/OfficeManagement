using System.ComponentModel.DataAnnotations;

namespace OfficeManagement.Data
{
    public class TouristPlace
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100, ErrorMessage = "The name cannot be longer than 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The address is required.")]
        [StringLength(200, ErrorMessage = "The address cannot be longer than 200 characters.")]
        public string? Address { get; set; }

        [Range(0, 5, ErrorMessage = "The rating must be between 0 and 5.")]
        public decimal Rating { get; set; }

        public string? ImageUrl { get; set; }

    }
}
