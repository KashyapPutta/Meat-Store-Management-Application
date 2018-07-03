using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class Vendor
    {
        [Display(Name = "Vendor Id")]
        public int VendorId { get; set; }
        [Required]
        [Display (Name = "Vendor Name")]
        public string VendorName { get; set; }
        [Required (ErrorMessage = "ContactNum number is Required*")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Vendor Contact No:")]
        public long ContactNum { get; set; }
        [Required(ErrorMessage = "Email Id is Required*")]
        //[EmailAddress(ErrorMessage = "Please Enter a Proper Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email ID is not valid.")]
        [Display(Name = "Vendor Email address")]
        public string EmailId { get; set; }
        [Display(Name = "Vendor Added Date")]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Vendor Physical Address")]
        public string Address { get; set; }
    }
}