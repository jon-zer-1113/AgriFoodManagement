using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriFoodManagementFR.Data;
using AgriFoodManagementFR.Models;

namespace AgriFoodManagementFR.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        // Afficher tous les employés
        public async Task<IActionResult> Index()
        {
            // Si l'ensemble d'entités 'ApplicationDbContext.Employee' n'est pas null, retourne la vue 'Index' avec tous les employés, sinon retourne une erreur
            return _context.Employee != null ? 
                          View(await _context.Employee.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Employee'  is null.");
        }

        // GET: Employees/Details/5
        // Afficher les détails d'un employé spécifique
        public async Task<IActionResult> Details(int? id)
        {
            // Si l'ID est null ou l'ensemble d'entités 'ApplicationDbContext.Employee' est null, retourne une erreur
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            // Trouve l'employé avec l'ID correspondant et retourne la vue 'Details', sinon retourne une erreur
            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        // Afficher la page de création d'un employé
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // Créer un nouvel employé
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Cellphone,Phone,Email")] Employee employee)
        {
            // Si le modèle est valide, ajoute le nouvel employé à l'ensemble d'entités et redirige vers la page 'Index', sinon retourne la vue 'Create' avec l'employé non valide
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        // Afficher la page de modification d'un employé
        public async Task<IActionResult> Edit(int? id)
        {
            // Si l'ID est null ou l'ensemble d'entités 'ApplicationDbContext.Employee' est null, retourne une erreur
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // Modifier un employé existant
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Cellphone,Phone,Email")] Employee employee)
        {
            // Si l'ID ne correspond pas à l'employé spécifié, retourne une erreur
            if (id != employee.Id)
            {
                return NotFound();
            }

            // Vérifie si le modèle d'employé est valide avant de l'enregistrer
            if (ModelState.IsValid)
            {
                try
                {
                    // Met à jour le modèle d'employé dans la base de données
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Si l'employé n'existe pas, retourne une erreur
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // Redirige vers la vue Index après avoir enregistré les modifications
                return RedirectToAction(nameof(Index));
            }
            // Retourne la vue Edit avec le modèle d'employé en cas d'erreur
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // Si l'ID est nul ou l'ensemble d'entités Employee est nul, retourne une erreur
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            // Récupère l'employé correspondant à l'ID spécifié
            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            // Si l'employé n'existe pas, retourne une erreur
            if (employee == null)
            {
                return NotFound();
            }

            // Affiche la vue Delete avec le modèle d'employé
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Si l'ensemble d'entités Employee est nul, retourne une erreur
            if (_context.Employee == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employee'  is null.");
            }
            // Récupère l'employé correspondant à l'ID spécifié
            var employee = await _context.Employee.FindAsync(id);
            // Si l'employé existe, le supprime de la base de données
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            // Enregistre les modifications dans la base de données
            await _context.SaveChangesAsync();
            // Redirige vers la vue Index après avoir supprimé l'employé
            return RedirectToAction(nameof(Index));
        }

        // Vérifie si l'employé avec l'ID spécifié existe dans la base de données
        private bool EmployeeExists(int id)
        {
          return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
