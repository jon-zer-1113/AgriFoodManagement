using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using AgriFoodManagementFR.Models;

namespace AgriFoodManagementFR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AgriFoodManagementFR.Models.Employee> Employee { get; set; } = default!;
        public DbSet<AgriFoodManagementFR.Models.Location> Location { get; set; } = default!;
        public DbSet<AgriFoodManagementFR.Models.Service> Service { get; set; } = default!;
    }
}

/*
Ce fichier est la classe de contexte de base de données de mon application. 
Il hérite de la classe IdentityDbContext, qui est une classe fournie par : le package Microsoft.AspNetCore.Identity.EntityFrameworkCore 
pour gérer les tables de base de données liées à l'authentification et à l'autorisation.
*/

/* 
"DbSet" pour chaque classe de modèle que j'ai créée (pour permettre l'accès à la table voulue dans ma base de données).
*/