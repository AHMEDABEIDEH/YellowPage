using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YellowPage.Models
{
    public class SuggestionClass
    {
        public int UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [Display(Name = "Email Name: ")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Suggestion is Required.")]
        [Display(Name = "Suggestion: ")]
        public string Suggestion { get; set; }
    }
}