using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SHNAR.Data;
using SHNAR.Models;

namespace SHNAR.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        private readonly SHNAR.Data.SchoolContext _context;

        public DetailsModel(SHNAR.Data.SchoolContext context)
        {
            _context = context;
        }

        public Alumno Alumno { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alumno = await _context.Alumnos
                .Include(s => s.Inscripciones)
                .ThenInclude(e => e.Materias)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Alumno == null)
            {
                return NotFound();
            }
            else
            {
                Alumno = Alumno;
            }
            return Page();
        }
    }
}
