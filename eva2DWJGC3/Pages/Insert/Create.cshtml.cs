using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Modelo;

namespace eva2DWJGC3.Pages.Insert
{
    public class CreateModel : PageModel
    {
        private readonly DAL.Modelo.BdEvaluacionContext _context;

        public CreateModel(DAL.Modelo.BdEvaluacionContext context)
        {
            _context = context;
        }



        public IActionResult OnGet()
        {

            Console.WriteLine("-------Entrando en el método crear-------");

        ViewData["CodEvaluacion"] = new SelectList(_context.EvaCatEvaluacions, "CodEvaluacion", "CodEvaluacion");
            return Page();

            
        }

        [BindProperty]
        public EvaTchNotasEvaluación EvaTchNotasEvaluación { get; set; }
        

        
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("-------Saliendo del método crear-------");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EvaTchNotasEvaluacións.Add(EvaTchNotasEvaluación);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
