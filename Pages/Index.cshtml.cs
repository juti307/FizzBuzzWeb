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


namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public GiveInt GiveInt { get; set; }
        public string Message { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = GiveInt.Fizzbuzz(GiveInt.Number);
                HttpContext.Session.SetString("SessionNumber", JsonConvert.SerializeObject(GiveInt));
                HttpContext.Session.SetString("SessionDate", JsonConvert.SerializeObject(DateTime.Today.ToString("d")));
                HttpContext.Session.SetString("SessionMessage", Message);

                //return RedirectToPage("./LastSearch");
            }
            return Page();
        }
}
}
