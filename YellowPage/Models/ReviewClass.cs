using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YellowPage.Models
{
    public class ReviewClass
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Review is Required.")]
        [Display(Name = "Review: ")]
        public string Review { get; set; }
    }
}