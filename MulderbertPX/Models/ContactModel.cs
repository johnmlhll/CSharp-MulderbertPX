using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition: Class data models the contact us data model. Class Extends DataModel Base Class (Ref: Helper Method 1)
    /// </summary>
    public class ContactModel
    {
        [Required(ErrorMessage = "First Name Required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First Name must contain alphabets")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last Name must contain alphabets")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Display(Name = "Contact Type")]
        public ContactType ContactClass { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Request Required")]
        [MaxLength(300, ErrorMessage ="Please ensure your online contact message is between 2 and 300 characters long")]
        [MinLength(2, ErrorMessage = "Please ensure your online contact message is greater then 2 characters long")]
        public string Request { get; set; }
    }
}
