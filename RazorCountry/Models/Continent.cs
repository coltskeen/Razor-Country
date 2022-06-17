using System.ComponentModel.DataAnnotations;

namespace RazorCountry.Models
{
    public class Continent
    {
        [Required, StringLength(2, MinimumLength = 2), Display(Name = "Code")] 
        [RegularExpression(@"[A-Z]+", ErrorMessage = "Only upper case characters are allowed.")]
        public string ID { get; set; }

        [Required] 
        public string Name { get; set; }

        /* Annotations Explaination
         * [Required] --> requires a a field to contain a value 
         * [StringLength(2, MinimumLength = 2) --> forces a 2 character input
         * [Display(Name = "Code")] --> Makes the display name more friendly
         * [RegularExpression ... ] --> Accepts only uppercase input and returns en error otherwise
         */
    }
}

