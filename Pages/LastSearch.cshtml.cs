using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Pages.Models;


namespace FizzBuzzWeb.Pages
{

    public class LastSearchModel : PageModel
    {
        private readonly ILogger<LastSearchModel> _logger;

        public LastSearchModel(ILogger<LastSearchModel> logger)
        {
            _logger = logger;
        }

        public GiveInt GiveInt { get; set; }
        public DateTime Data { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            var SessionGiveInt = HttpContext.Session.GetString("SessionNumber");    
            var SessionDate = HttpContext.Session.GetString("SessionDate");
            if (SessionGiveInt != null)
            {
                Message = HttpContext.Session.GetString("SessionMessage");
                GiveInt = JsonConvert.DeserializeObject<GiveInt>(SessionGiveInt);
                Data = JsonConvert.DeserializeObject<DateTime>(SessionDate); 
            }
        }
    }
}
