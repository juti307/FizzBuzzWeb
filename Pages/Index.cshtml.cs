using FizzBuzzWeb.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SearchesContext _context;
        [BindProperty]
        public GiveInt GiveInt { get; set; }
        public string Msg { get; set; }
        public IdentityUser GetUser { get; set; }
        public IndexModel(ILogger<IndexModel> logger, SearchesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                
                Msg = GiveInt.Fizzbuzz(GiveInt.Number);
                HttpContext.Session.SetString("SessionNumber", JsonConvert.SerializeObject(GiveInt));
                HttpContext.Session.SetString("SessionDate", JsonConvert.SerializeObject(DateTime.Now));
                HttpContext.Session.SetString("SessionMessage", Msg);

                using (_context)
                {
                    var src = new Searches()
                    {
                        Date = DateTime.Now,
                        Number = GiveInt.Number,
                        Message = Msg,
                        User = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };
                    _context.Searches.Add(src);
                    await _context.SaveChangesAsync();
                }

                //return RedirectToPage("./LastSearch");
            }
            return Page();
        }
}
}
