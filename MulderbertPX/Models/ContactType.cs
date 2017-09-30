using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    public enum ContactType
    {
        [Display(Name ="General Account Enquiry")]
        AccountEnquiry,
        [Display(Name ="Sales Enquiry - ProductModel")]
        ProductEnquiry,
        [Display(Name ="Sales Enquiry - Service")]
        ServiceEnquirty,
        [Display(Name = "Sales Enquiry - Combined Solution")]
        CombinedSalesEnquiry,
        [Display(Name ="Customer Service")]
        CustomerService,
        [Display(Name ="Company or ProductModel Feedback")]
        Feedback,
        General
    }
}