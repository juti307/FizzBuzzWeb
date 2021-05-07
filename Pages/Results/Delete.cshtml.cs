using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Pages.Models;

namespace FizzBuzzWeb.Pages.Results
{
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.SearchesContext _context;

        public DeleteModel(FizzBuzzWeb.Data.SearchesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Searches Searches { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Searches = await _context.Searches.FirstOrDefaultAsync(m => m.Id == id);

            if (Searches == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Searches = await _context.Searches.FindAsync(id);

            if (Searches != null)
            {
                _context.Searches.Remove(Searches);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
