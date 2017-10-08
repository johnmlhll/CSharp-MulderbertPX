using System;
using MulderbertPX.Models;
using System.Web.Mvc;

namespace MulderbertPX.Controllers
{
    /// <summary>
    /// Class Definition: Controlling Data Flows from Product Range view to back end
    /// </summary>
    public class ProductRangeController : Controller
    {
        // GET: ProductRange
        //Declare Objects/Variables
        DataProcessing Data { get; set; }

        //initial page authentication using constructor
        public ProductRangeController()
        {
            if (LoginModel.AuthenticatedLogin == true)
            {
                new LoginAuthentication().RenewAuthenticatedCookie();
            }
        }

        /***
         * Method 1 - Main Page View Controller for ProductRangeController class
         */
        public ActionResult Index()
        {
            return View("Index");
        }
        /**
         * Method 2 - OrderAcceptance Conteroller 
         */
        public ActionResult AcceptOrder(ProductModel order)
        {
            if (ModelState.IsValid & Request.IsAuthenticated)
            {
                Data = new DataProcessing();
                bool validCalculation = CalculateOrder(order);
                if (validCalculation)
                {
                    string orderType = order.OrderType.ToString();
                    string productName = order.ProductName.ToString(); //difference - not truly APIE - AcceptOrder ! IS-A AcceptServiceOrder
                    string productDescription = order.ProductDescription.ToString();
                    int unitPrice = order.UnitPrice;
                    int netTotal = order.NetTotal;
                    double tax = order.TaxTotal;
                    double orderTotal = order.OrderTotal;
                    string unitQuanity = order.UnitQuanity.ToString();
                    string billingStatus = order.BillingStatus.ToString();
                    int customerID = DataModel.CustomerID;
                    bool orderAccepted = Data.AddNewOrder(orderType, productName,
                        productDescription, unitPrice, netTotal, tax, orderTotal, unitQuanity, billingStatus, customerID);
                    if (orderAccepted == false) { return RedirectToAction("Index", "ProductRange"); }
                }
                else
                {
                    return RedirectToAction("Index", "ProductRange");
                }
                return View("AcceptOrder", order);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        /**
         * Helper Method 1 - Process/Calculate the order from ProductModel Range returning a list of data attrbute values
         */
        private bool CalculateOrder(ProductModel order)
        {
            bool completedCalculation = false;
            double taxRate = 0.23;
            try
            {
                switch (order.ProductName)
                {
                    case ProductList.BekoRx7:
                        order.ProductDescription = EnumDescription.GetDescription(ProductList.BekoRx7);
                        order.OrderType = ProductType.GoodsPurchase;
                        order.UnitPrice = 1099;
                        order.BillingStatus = BillingState.Unbilled;
                        //run calculation based on quantity
                        switch (order.UnitQuanity)
                        {
                            case Quantity.One:
                                order.NetTotal = order.UnitPrice * 1;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Two:
                                order.NetTotal = order.UnitPrice * 2;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;

                                break;
                            case Quantity.Three:
                                order.NetTotal = order.UnitPrice * 3;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Four:
                                order.NetTotal = order.UnitPrice * 4;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Five:
                                order.NetTotal = order.UnitPrice * 5;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            default:
                                Console.WriteLine("Error Selection of Value - <> 1 - 5 selected for product: "+order.ProductName);
                                break;
                        }
                        completedCalculation = true;
                        break;
                    case ProductList.IndustrialYr9:
                        order.ProductDescription = EnumDescription.GetDescription(ProductList.IndustrialYr9);
                        order.OrderType = ProductType.GoodsPurchase;
                        order.UnitPrice = 1499;
                        order.BillingStatus = BillingState.Unbilled;
                        //run calculation based on quantity
                        switch (order.UnitQuanity)
                        {
                            case Quantity.One:
                                order.NetTotal = order.UnitPrice * 1;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Two:
                                order.NetTotal = order.UnitPrice * 2;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;

                                break;
                            case Quantity.Three:
                                order.NetTotal = order.UnitPrice * 3;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Four:
                                order.NetTotal = order.UnitPrice * 4;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Five:
                                order.NetTotal = order.UnitPrice * 5;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            default:
                                Console.WriteLine("Error Selection of Value - <> 1- 5 selected for product: " + order.ProductName);
                                break;
                        }
                        completedCalculation = true;
                        break;
                    case ProductList.StoreDr9:
                        order.ProductDescription = EnumDescription.GetDescription(ProductList.StoreDr9);
                        order.OrderType = ProductType.GoodsPurchase;
                        order.UnitPrice = 4799;
                        order.BillingStatus = BillingState.Unbilled;
                        //run calculation based on quantity
                        switch (order.UnitQuanity)
                        {
                            case Quantity.One:
                                order.NetTotal = order.UnitPrice * 1;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Two:
                                order.NetTotal = order.UnitPrice * 2;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Three:
                                order.NetTotal = order.UnitPrice * 3;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Four:
                                order.NetTotal = order.UnitPrice * 4;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Five:
                                order.NetTotal = order.UnitPrice * 5;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            default:
                                Console.WriteLine("Error Selection of Value - <> 1- 5 selected for product: " + order.ProductName);
                                break;
                        }
                        completedCalculation = true;
                        break;
                    case ProductList.AN6WalkIn:
                        order.ProductDescription = EnumDescription.GetDescription(ProductList.AN6WalkIn);
                        order.OrderType = ProductType.GoodsPurchase;
                        order.UnitPrice = 13499;
                        order.BillingStatus = BillingState.Unbilled;
                        //run calculation based on quantity
                        switch (order.UnitQuanity)
                        {
                            case Quantity.One:
                                order.NetTotal = order.UnitPrice * 1;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Two:
                                order.NetTotal = order.UnitPrice * 2;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;

                                break;
                            case Quantity.Three:
                                order.NetTotal = order.UnitPrice * 3;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Four:
                                order.NetTotal = order.UnitPrice * 4;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            case Quantity.Five:
                                order.NetTotal = order.UnitPrice * 5;
                                order.TaxTotal = order.NetTotal * taxRate;
                                order.OrderTotal = order.NetTotal + order.TaxTotal;
                                break;
                            default:
                                Console.WriteLine("Error Selection of Value - <> 1- 5 selected for product: " + order.ProductName);
                                break;
                        }
                        completedCalculation = true;
                        break;
                    default:
                        Console.WriteLine("Error Selection of ProductModel Not Valid ProductModel Range for product: " + order.ProductName);
                        order.BillingStatus = BillingState.Suspended;
                        break;
                }
            }
            catch (NullReferenceException nr)
            {
                Console.WriteLine("Null Reference Exception. Details: {0}", nr.Message);
            }
            return completedCalculation;
        }
    }
}
 