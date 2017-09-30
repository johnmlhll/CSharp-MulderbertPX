using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition: Data Model class for product orders calcaluting product price, quanity, net, tax and total order value for customer orders. Inherits DataModel() class
    /// </summary>
    public class ProductModel: DataModel
    {
        [Display(Name = "Product Type")]
        public ProductType OrderType { get; set; }

        [Display(Name = "Product Name")]
        public ProductList ProductName { get; set; }

        [Display(Name = "Fridge Services")]
        public ServiceList ServiceName { get; set; }

        [Display(Name = "Product Description")]
        [MaxLength(200, ErrorMessage ="Must be less then 140 characters")]
        public string ProductDescription { get; set; }

        [Display(Name = "Product Unit Price")]
        public int UnitPrice { get; set; }

        [Display(Name = "Net Price Less Tax")]
        [Required]
        public int NetTotal { get; set; }

        [Display(Name = "Tax Total")]
        public double TaxTotal { get; set; }

        [Display(Name = "Total Order Price")]
        public double OrderTotal { get; set; }

        [Display(Name = "Product Quanity")]
        public Quantity UnitQuanity { get; set; }

        [Display(Name ="Billing Status")]
        public BillingState BillingStatus { get; set; }
    }
}