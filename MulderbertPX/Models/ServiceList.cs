using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition:  Define Enums for Available Products (Goods) at Mulderbert
    /// </summary>
    public enum ServiceList
    {
        Select,
        [Display(Name = "Fridge Services")]
        [Description("Full Service Level offering with maintenance and repair callout along with telephone support")]
        FridgeServices,
        [Display(Name = "Technical Support")]
        [Description("Technical Support offering via phone and online service including training material on maintanence and operation of products")]
        TechnicalSupport
    }
}