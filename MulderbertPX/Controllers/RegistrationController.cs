using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MulderbertPX.Models;
using System.Web.Security;


namespace MulderbertPX.Controllers
{
    /// <summary>
    /// Class Definition: Controlling Registration View Data flows to back end
    /// </summary>
    public class RegistrationController : Controller
    {
        //Declare vars/objs
        private DataProcessing Data { get; set; }

        //initial page authentication
        public RegistrationController()
        {
            if (LoginModel.AuthenticatedLogin == true)
            {
                new LoginAuthentication().RenewAuthenticatedCookie();
            }
        }
        /**
         * Method 1 - Standard Action Method for Registration View to DB Dataflow
         */
        public ActionResult Index()
        {
            return View("Index");
        }
        /**
         * Method 2 - Customer Registration Action Method for Registration Validation and Save to DB
         */
        public ActionResult RegSuccess(CustomerModel newCustomer)
        {
            if (ModelState.IsValid & newCustomer.TermsAndConditionsOk == true)
            {
                Data = new DataProcessing();
                if (Data.AddNewUser(newCustomer))
                {
                    return View("RegSuccess", newCustomer);
                }
                else {
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
        }
    }

