using System.ComponentModel.DataAnnotations;

namespace AgriFoodManagementFR.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string? City { get; set; }
    }
}
