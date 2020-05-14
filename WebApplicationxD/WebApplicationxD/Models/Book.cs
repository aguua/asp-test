using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplicationxD.Models
{
    public class Book : IValidatableObject
        {
            public int Id { get; set; }
            [Required]
            public string Title { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Release date cannot be null")]
            [Display(Name = "Release Date")]
            [DataType(DataType.Date)]
            public DateTime ReleaseDate { get; set; }
            public string Series { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Category cannot be null")]
            public string Category { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose author")]
            public int AuthorId { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose author")]
            public Author Author { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (ReleaseDate > DateTime.Now)
                {
                    yield return new ValidationResult("Can not add not realised book.",
                        new[] { nameof(ReleaseDate) });
                }
            }
        }
    
}
