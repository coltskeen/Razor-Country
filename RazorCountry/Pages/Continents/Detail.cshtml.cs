using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCountry.Models;
using RazorCountry.Data;

namespace RazorCountry.Pages.Continents
{
    public class DetailModel : PageModel
    {
        private readonly CountryContext _context;

        public DetailModel(CountryContext context)
        {
            _context = context;
        }

        public Continent Continent { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Continent = await _context.Continents.FindAsync(id);

            if (Continent == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
