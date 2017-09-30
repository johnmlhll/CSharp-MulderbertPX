using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Reflection;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Enum Class Summary - Define Enums for Available Products (Goods) at Mulderbert
    /// </summary>
    public enum ProductList
    {
        Select,
        [Display(Name = "Beko Rx7 Fridge")]
        [Description("The Beko tall larder fridge offers a space saving design with all the top quality features")]
        BekoRx7,
        [Display(Name = "Industrial Yr9 Fridge")]
        [Description("The two stainless steel allowing for large volumes food to be chilled")]
        IndustrialYr9,
        [Display(Name = "Store Dr9 Cooler")]
        [Description("High Performance unit. It has concealed hinges creating a seamless finish, while flat along with vertically brushed EZKleen stainless steel doors")]
        StoreDr9,
        [Display(Name = "AN-6 Walk-in Cooler")]
        [Description("Walk in Unit. Condensated Evaporator Refrigeration system is flush to the ceiling for 100% use of interior space.")]
        AN6WalkIn
    }
}