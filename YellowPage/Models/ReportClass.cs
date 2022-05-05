using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace YellowPage.Models
{
    public class ReportClass
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Report is Required.")]
        [Display(Name = "Report: ")]
        public string Report { get; set; }
    }
}