using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Pages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FizzBuzzWeb.Pages.Results
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzWeb.Data.SearchesContext _context;

        public IndexModel(FizzBuzzWeb.Data.SearchesContext context)
        {
            _context = context;
        }

        public IList<Searches> Searches { get;set; }
        public string GetUser { get; set; }

        public async Task OnGetAsync()
        {
            GetUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Searches = await _context.Searches
                .OrderByDescending(p=>p.Date)
                .Take<Searches>(20)
                .ToListAsync();
            
        }
        
    }
}
