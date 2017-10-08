using System;
using System.Web.Mvc;
using MulderbertPX.Models;

namespace MulderbertPX.Controllers
{
    /// <summary>
    /// Class Definition - Controlling Product Service data flow to back end
    /// </summary>
    public class ProductServiceController : Controller
    {
        //Declare Objects/Variables
        DataProcessing Data { get; set; }
        //initial page authentication using constructor
        public ProductServiceController()
        {
            if (LoginModel.AuthenticatedLogin == true)
            {
                new LoginAuthentication().RenewAuthenticatedCookie();
            }
        }
        /*
         * Method 1 - Standard Service View ActionResult method
         */
        public ActionResult Index()
        {
            return View("Index");
        }
        /**
         * Method 2 - OrderAcceptance Conteroller 
         */
        public ActionResult AcceptServiceOrder(ProductModel order)
        {
            if (ModelState.IsValid & Request.IsAuthenticated)
            {
                Data = new DataProcessing();
                bool validCalculation = CalculateOrder(order);
                if (validCalculation)
                {
                    string orderType = order.OrderType.ToString();
                    string serviceName = order.ServiceName.ToString(); //difference - not truly APIE - AcceptServiceOrder ! IS-A AcceptOrder
                    string productDescription = order.ProductDescription.ToString();
                    int unitPrice = order.UnitPrice;
                    int netTotal = order.NetTotal;
                    double tax = order.TaxTotal;
                    double orderTotal = order.OrderTotal;
                    string unitQuanity = order.UnitQuanity.ToString();
                    string billingStatus = order.BillingStatus.ToString();
                    int customerID = DataModel.CustomerID;
                    bool orderAccepted = Data.AddNewOrder(orderType, serviceName,
                        productDescription, unitPrice, netTotal, tax, orderTotal, unitQuanity, billingStatus, customerID);
                    if (orderAccepted == false) { return RedirectToAction("Index", "ProductService"); }
                }
                else
                {
                    return RedirectToAction("Index", "ProductService");
                }
                return View("AcceptServiceOrder", order);

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
                switch (order.ServiceName)
                {
                    case ServiceList.FridgeServices:
                        order.ProductDescription = EnumDescription.GetDescription(ServiceList.FridgeServices);
                        order.OrderType = ProductType.ServiceSubscription;
                        order.UnitPrice = 4000;
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
                                Console.WriteLine("Error Selection of Value - <> 1 - 5 selected for product: " + order.ProductName);
                                break;
                        }
                        completedCalculation = true;
                        break;
                    case ServiceList.TechnicalSupport:
                        order.ProductDescription = EnumDescription.GetDescription(ServiceList.TechnicalSupport);
                        order.OrderType = ProductType.ServiceSubscription;
                        order.UnitPrice = 1000;
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
                                Console.WriteLine("Error Selection of Value - <> 1 - 5 selected for product: " + order.ProductName);
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