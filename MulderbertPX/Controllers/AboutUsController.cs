using System.Web.Mvc;
using MulderbertPX.Models;

namespace MulderbertPX.Controllers
{
    /// <summary>
    /// Class Definition: Manages AboutUs View Data Process to Back end 
    /// </summary>
    public class AboutUsController : Controller
    {
        //initial page authentication
        public AboutUsController()
        {
            if (LoginModel.AuthenticatedLogin == true)
            {
                new LoginAuthentication().RenewAuthenticatedCookie();
            }
        }
        /*
         * Method 1 - Standard Main View for About Us
         */
        public ActionResult Index()
        {
            return View();
        }
    }
}