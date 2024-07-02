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
    public class DetailsModel : PageModel
    {
        private readonly SHNAR.Data.SchoolContext _context;

        public DetailsModel(SHNAR.Data.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
