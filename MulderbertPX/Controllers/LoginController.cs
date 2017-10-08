using System.Web.Security;
using System.Web.Mvc;
using MulderbertPX.Models;


namespace MulderbertPX.Controllers
{ 
    /// <summary>
    /// Class Definition: Controller Class for Login Process
    /// </summary>
    public class LoginController : Controller
    {
        //declare objs
        DataProcessing dataProcessing;
        LoginAuthentication authenticateLogin;

        /*
         * Method 1 - Main login view
         */ 
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        /*
         * Method 2 ActionResult method - Takes login and processes it via DB check and initialises ID'd session
         */
        [HttpPost]
        public ActionResult LoginSuccess(LoginModel login)
        {
            dataProcessing = new DataProcessing();
            authenticateLogin = new LoginAuthentication();
            bool goodCookie = false;
            if (ModelState.IsValid)
            {
                string message = "";
                if (dataProcessing.CheckLogin(login))
                {                              
                    LoginModel.AuthenticatedLogin = true;
                    ViewBag.ScreenName = login.Username;
                    DataModel.CustomerID = dataProcessing.GetCustomerID(login.Username.ToString());
                    goodCookie = authenticateLogin.CreateNewTicket(login.Username);
                    if (goodCookie) { authenticateLogin.RenewAuthenticatedCookie(); }
                    message = "Login Success";
                    ViewData["message"] = message;
                }
                else
                {
                    message = "Login Failed Authentication";
                    ViewData["message"] = message;
                    ModelState.Clear();
                    return View("Index");
                }
                return View("LoginSuccess", login);
            }
            else
            {
                return View("Index");
            }
        }
        /*
         * Method 3 - Action Method for Logging Out
         */
        public ActionResult Logout()
        {
            LoginModel.AuthenticatedLogin = false;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}