using SHNAR.Models.SchoolViewModels;
using SHNAR.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHNAR.Models;

namespace SHNAR.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchoolContext _context;

        public AboutModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Alumnos { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from alumno in _context.Alumnos
                group alumno by alumno.InscripcionFecha into dateGroup
                select new EnrollmentDateGroup()
                {
                    InscripcionFecha = dateGroup.Key,
                    AlumnoCount = dateGroup.Count()
                };

            Alumnos = await data.AsNoTracking().ToListAsync();
        }
    }
}