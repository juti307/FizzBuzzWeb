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
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.SearchesContext _context;

        public IndexModel(FizzBuzzWeb.Data.SearchesContext context)
        {
            _context = context;
        }

        public IList<Searches> Searches { get;set; }

        public async Task OnGetAsync()
        {
            Searches = await _context.Searches
                .OrderByDescending(p=>p.Date)
                .Take<Searches>(10)
                .ToListAsync();
            
        }
        
    }
}
