using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace eva2DWJGC3.Pages.Select
{
    public class IndexModel : PageModel
    {
        private readonly DAL.Modelo.BdEvaluacionContext _context;

        public IndexModel(DAL.Modelo.BdEvaluacionContext context)
        {
            _context = context;
        }

        public IList<EvaTchNotasEvaluación> EvaTchNotasEvaluación { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Console.WriteLine("--------mostrando elementos:-------");
            if (_context.EvaTchNotasEvaluacións != null)
            {
                EvaTchNotasEvaluación = await _context.EvaTchNotasEvaluacións
                .Include(e => e.CodEvaluacionNavigation).ToListAsync();
            }
        }
    }
}
