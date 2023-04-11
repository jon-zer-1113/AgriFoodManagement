using System.ComponentModel.DataAnnotations;

namespace AgriFoodManagementFR.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
