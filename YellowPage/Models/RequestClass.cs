using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YellowPage.Models
{
    public class RequestClass
    {
        public int BusinessId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Company Name is Required.")]
        [Display(Name = "Company: ")]
        public string Company { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category is Required.")]
        [Display(Name = "Category: ")]
        public string Category { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is Required.")]
        [Display(Name = "Address: ")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone is Required.")]
        [Display(Name = "Phone: ")]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required.")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Website is Required.")]
        [Display(Name = "Website: ")]
        public string Website { get; set; }
    }
}