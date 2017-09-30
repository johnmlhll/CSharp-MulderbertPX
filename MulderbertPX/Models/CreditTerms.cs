using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Description - Enum class structuring payment terms upon registration
    /// </summary>
    public enum CreditTerms
    {
        Prepaid,
        [Display(Name = "7 Days")]
        Credit7Days,
        [Display(Name = "30 Days")]
        Credit30Days,
        [Display(Name = "60 Days")]
        Credit60Days,
        [Display(Name = "90 Days")]
        Credit90Days,
        [Display(Name = "120 Days")]
        Credit120Days,
        [Display(Name = "150 Days")]
        Credit150Days,
        [Display(Name = "Credit Card Only")]
        CreditCard,
        [Display(Name = "No Credit Requested")]
        NoCredit
    }
}