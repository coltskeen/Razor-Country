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
            //Continent = await _context.Continents.FindAsync(id);

            /* Instead of FindAsync() using FirstOrDefaultAsync() 
             * because it has more flexibility finding more then just the id.
             * Additionally adding a record retrieval modifier .Include() to 
             * inlcude the list of related countries on the detail page.
             * AsNoTracking() is an EF hint that says we will not be updating the countries. 
             * This improves performance.
             */

            //Record Retrieval modified to have .Include to inlcude the list of related countries on the detail page
            Continent = await _context.Continents
              .Include(c => c.Countries)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

            if (Continent == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}