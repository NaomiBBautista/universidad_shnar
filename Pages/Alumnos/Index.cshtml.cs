using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHNAR.Data;
using SHNAR.Models;

namespace SHNAR.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        private readonly SHNAR.Data.SchoolContext _context;

        private readonly IConfiguration Configuration;

        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Alumno> Alumnos { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            CurrentFilter = searchString;

            IQueryable<Alumno> alumnosIQ = from a in _context.Alumnos
                                           select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                alumnosIQ = alumnosIQ.Where(a => a.Apellido.Contains(searchString)
                                       || a.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    alumnosIQ = alumnosIQ.OrderByDescending(a => a.Apellido);
                    break;
                case "Date":
                    alumnosIQ = alumnosIQ.OrderBy(a => a.InscripcionFecha);
                    break;
                case "date_desc":
                    alumnosIQ = alumnosIQ.OrderByDescending(a => a.InscripcionFecha);
                    break;
                default:
                    alumnosIQ = alumnosIQ.OrderBy(a => a.Apellido);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Alumnos = await PaginatedList<Alumno>.CreateAsync(
                alumnosIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
