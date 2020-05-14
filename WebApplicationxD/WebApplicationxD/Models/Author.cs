using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplicationxD.Models
{
    public class Author : IValidatableObject
    {

            public int Id { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be null")]
            public string Name { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime DateOfBirth { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "Nationality cannot be null")]
            public string Nationality { get; set; }
            public List<Book> Books { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                Regex regex = new Regex(@"^([A-Z]{1,}|\d)[A-Za-z ]*$");
                if (!regex.IsMatch(Name))
                {
                    yield return new ValidationResult("Name should start with letter",
                        new[] { nameof(Name) });
                }
            }
        }
    
}
