using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzWeb.Pages.Models
{
    public class Searches
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(1, 1000)]
        [Column(TypeName = "int")]
        public int Number { get; set; }
        [Required]
        [MaxLength(200)]
        public string Message { get; set; }
        public string User { get; set; } 


    }
}
