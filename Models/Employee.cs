using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;
// Importation des bibliothèques (System. , Mono. , etc...)

namespace AgriFoodManagementFR.Models // Définition du namespace
{
    public class Employee // Définition de la classe Employee
    {
        public int Id { get; set; } // Propriété Id de type int, permettant de stocker l'identifiant de l'employé

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

// Il y a également les différentes propriété de cette classe comme : "Firstname", "Lastname", etc...

/*
"[Required(ErrorMessage = "Le prénom est obligatoire.")]" garantit que la propriété ne peut pas être nulle ou vide. 
Si on essaye d'ajouter un Employee sans prénom, on obtiendra une erreur de validation. 
Cette validation garantit que chaque Employee doit avoir un prénom.
*/
