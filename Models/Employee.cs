using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;

namespace AgriFoodManagementFR.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        [Required]
        public string? Cellphone { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }
    }
}

/*
"[Required(ErrorMessage = "Le prénom est obligatoire.")]" garantit que la propriété ne peut pas être nulle ou vide. 
Si on essaye d'ajouter un Employee sans prénom, on obtiendra une erreur de validation. 
Cette validation garantit que chaque Employee doit avoir un prénom.
*/
