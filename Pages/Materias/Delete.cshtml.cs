using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SHNAR.Data;
using SHNAR.Models;

namespace SHNAR.Pages.Materias
{
    public class DeleteModel : PageModel
    {
        private readonly SHNAR.Data.SchoolContext _context;

        public DeleteModel(SHNAR.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Materia Materia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FirstOrDefaultAsync(m => m.ID == id);

            if (materia == null)
            {
                return NotFound();
            }
            else
            {
                Materia = materia;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                Materia = materia;
                _context.Materias.Remove(Materia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
