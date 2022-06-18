using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCountry.Models;
using RazorCountry.Data;

namespace RazorCountry.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly CountryContext _context;

        public IndexModel(CountryContext context)
        {
            _context = context;
        }

        public List<Country> Countries { get; set; }

        //LINQ search code and filters when search string is entered
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            //Defaults to search all
            var countries = from c in _context.Countries
                            select c;

            //If a search string is entered it filters the results
            if (!string.IsNullOrEmpty(SearchString))
            {
                countries = countries.Where(c => c.Name.Contains(SearchString));
            }

            //ToListAsync() gets the results
            Countries = await countries.ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country Country = await _context.Countries.FindAsync(id);

            if (Country != null)
            {
                _context.Countries.Remove(Country);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}