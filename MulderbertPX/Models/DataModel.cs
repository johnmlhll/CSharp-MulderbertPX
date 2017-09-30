using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition: Base Call for Product and Customer Model classes that defines stored data CustomerID numbers plus other common properities
    /// </summary>
    public class DataModel
    {
        //Has to be a static as login.username is passed in from Login model and used in finding customer ID for Product ID saving (cross model data transfer)
        public static int CustomerID { get; set; }
    }
}