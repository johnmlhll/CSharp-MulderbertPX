using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MulderbertPX.Models;

namespace MulderbertPX.Controllers
{
    /// <summary>
    /// Class Definition: Main controller for home view
    /// </summary>
    public class HomeController : Controller
    {
        //initial page authentication using constructor
        public HomeController()
        {
            if (LoginModel.AuthenticatedLogin == true)
            {
                new LoginAuthentication().RenewAuthenticatedCookie();
            }
        }
        /**
         * Method 1 - Main controller method for Home page view
         */
        public ActionResult Index()
        {
            return View();
        }
    }
}