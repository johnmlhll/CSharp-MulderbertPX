using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MulderbertPX.Models;

namespace MulderbertPX.Controllers
{
    /// <summary>
    /// Class Definition: Controlling Site Map data flow to back end 
    /// </summary>
    public class SiteMapController : Controller
    {
        //initial page authentication using constructor
        public SiteMapController()
        {
            if (LoginModel.AuthenticatedLogin == true)
            {
                new LoginAuthentication().RenewAuthenticatedCookie();
            }
        }
        /**
          * Method 1 - Main view/controller method for Site Map
          */
        public ActionResult Index()
        {
            return View();
        }
    }
}