using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    public enum CountryType
    {
        Albania,
        Algeria,
        Andorra,
        Australia,
        Austria,
        Belgium,
        Bulgaria,
        Canada,
        China,
        Cyprus,
        [Display(Name="Czech Republic")]
        CzechRepublic,
        Denmark,
        Estonia,
        Finland,
        France,
        [Display(Name ="French Guiana")]
        FrenchGuiana,
        Germany,
        Greece,
        Iceland,
        India,
        Indonesia,
        Ireland,
        Italy,
        Japan,
        Kosovo,
        Lithuania,
        Luxembourg,
        [Display(Name = "Republic of Macedonia")]
        Macedonia,
        Malta,
        Netherlands,
        Norway,
        Poland,
        Portugal,
        Romania,
        [Display(Name="Russian Federation")]
        Russia,
        Serbia,
        [Display(Name = "Slovak Republic")]
        Slovakia,
        Slovenia,
        Spain,
        Sweden,
        Switzerland,
        Turkey,
        Ukraine,
        [Display(Name = "United Kingdom")]
        UK,
        [Display(Name= "United States of America ")]
        USA,
        Other
    }
}