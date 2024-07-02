using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SHNAR.Data;
using SHNAR.Models;

namespace SHNAR.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
        private readonly SHNAR.Data.SchoolContext _context;

        public CreateModel(SHNAR.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Alumno Alumno { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyAlumno = new Alumno();

            if (await TryUpdateModelAsync<Alumno>(
                emptyAlumno,
                "alumno",   // Prefix for form value.
                a => a.Nombre, a => a.Apellido, a => a.InscripcionFecha))
            {
                _context.Alumnos.Add(emptyAlumno);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
