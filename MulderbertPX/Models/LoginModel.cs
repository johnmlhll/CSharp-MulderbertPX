using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    /// <summary>
    ///  LoginModel Class definition: To Data Model the Login Credential Properties. Inherits DataModel() class
    /// </summary>
    public class LoginModel: DataModel
    {
        /**
         * Data Properties for Login with Validations
         */
        [Required(ErrorMessage = "Username Required")]
        [MinLength(2, ErrorMessage = "Minimum of 2 characters in your username and max of 15 characters")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 characters allowed in the user name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MinLength(8, ErrorMessage = "Password must be 8 characters and under 15 characters")]
        [MaxLength(15, ErrorMessage = "Password must be under 15 characters")]
        public string Password { get; set; }

        //internal login authenticator
        public static bool AuthenticatedLogin { get; set; }
    }
}