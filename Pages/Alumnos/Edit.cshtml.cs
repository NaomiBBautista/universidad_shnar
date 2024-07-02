using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHNAR.Data;
using SHNAR.Models;

namespace SHNAR.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        private readonly SHNAR.Data.SchoolContext _context;

        public EditModel(SHNAR.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Alumno Alumno { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alumno = await _context.Alumnos.FindAsync(id);

            if (Alumno == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var alumnoToUpdate = await _context.Alumnos.FindAsync(id);

            if (alumnoToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Alumno>(
                alumnoToUpdate,
                "alumno",
                a => a.Nombre, a => a.Apellido, a => a.InscripcionFecha))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.ID == id);
        }
    }
}
