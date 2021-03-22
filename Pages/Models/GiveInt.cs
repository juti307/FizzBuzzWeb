using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzWeb.Pages.Models
{
    public class GiveInt
    {
        [Display(Name = "Podaj liczbę ")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(1, 1000)]
        [Column(TypeName = "int")]
        public int Number { get; set; }

        public static string Fizzbuzz(int numb)
        {
            string result = "";
            if (numb % 3 == 0 && numb % 5 == 0)
                return result += "Otrzymano: FizzBuzz";
            else if (numb % 3 == 0)
                return result += "Otrzymano: Fizz";
            else if (numb % 5 == 0)
                return result += "Otrzymano: Buzz";
            else
                return result += ("Liczba: " + numb + " nie spełnia kryteriów Fizz/Buzz");
        }
    }
}
