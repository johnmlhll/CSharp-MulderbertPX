using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition: Class models the customer registration master file data model.
    /// </summary>
    public class CustomerModel
    {
        [Display(Name ="Company Name")]
        [MaxLength(50, ErrorMessage ="Must be less then 50 characters long")]
        public string CompanyName { get; set; } 

        [Required(ErrorMessage = "First Name Required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First Name must contain letters only")]
        [Display(Name ="First Name")]
        [MaxLength(25, ErrorMessage = "First Name but be under 25 characters long")]
        public string ContactFirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last Name must contain letters only")]
        [Display(Name ="Last Name")]
        [MaxLength(35, ErrorMessage = "Last Name but be under 35 characters long")]
        public string ContactLastName { get; set; }

        [Required(ErrorMessage = "Username Required")]
        [MinLength(2, ErrorMessage = "Minimum of 2 characters in your username and max of 15 characters")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 characters allowed in the user name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MinLength(8, ErrorMessage = "Password must be 8 characters and under 15 characters")]
        [MaxLength(15, ErrorMessage = "Password must be under 15 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [MinLength(3, ErrorMessage = "Password must be greater than 3 characters and under 101 characters")]
        [MaxLength(100, ErrorMessage = "Password must be under 101 characters")]
        [Display(Name ="Street Address")]
        public string AddressLine1 { get; set; }

        [Display(Name ="Area")]
        [Required(ErrorMessage = "Local Area Required")]
        [MaxLength(50, ErrorMessage ="Field must be less than 50 characters")]
        public string AddressLine2 { get; set; }    //Address Line 2 is usally optional

        [MaxLength(50, ErrorMessage = "Field must be less than 50 characters")]
        public string City { get; set; }

        [Required]
        public CountryType Country { get; set; }

        [Required(ErrorMessage = "Postcode Required")]
        [Display(Name ="Post Code")]
        [MaxLength(30, ErrorMessage = "Field must be less than 50 characters")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Email Contact Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Phone Number Required")]
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name ="Company Number")]
        public string CompanyNumber { get; set; }

        [Display(Name ="Tax/VAT Number")]
        public string TaxVatNumber { get; set; }

        [Display(Name ="Customer Type")]
        public ProductType CustomerType { get; set; }

        [Display(Name ="Payment Terms")]
        public CreditTerms PaymentTerms { get; set; }

        [Range(typeof(bool), "true","true", ErrorMessage ="Please accept Terms & Conditions by ticking the checkbox")]
        [Display(Name ="Accept Terms and Conditions")]
        public bool TermsAndConditionsOk { get; set; }
    }
}