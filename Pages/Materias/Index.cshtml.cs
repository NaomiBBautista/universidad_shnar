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
    public class IndexModel : PageModel
    {
        private readonly SHNAR.Data.SchoolContext _context;

        public IndexModel(SHNAR.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Materia> Materia { get;set; }

        public async Task OnGetAsync()
        {
            Materia = await _context.Materias
                .Include(m => m.Inscripciones)
                .Include(m => m.Maestros)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
