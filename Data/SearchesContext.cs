using FizzBuzzWeb.Pages.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzWeb.Data
{
    public class SearchesContext : DbContext
    {
        public DbSet<Searches> Searches { get; set; }

        public SearchesContext(DbContextOptions options) : base(options) { }
    }
}
