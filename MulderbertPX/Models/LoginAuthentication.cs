using System;
using System.Web;
using System.Web.Security;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition: To Authenticate Logged in status on all views using shared view layout
    /// </summary>
    public class LoginAuthentication
    {
        /*
         * Method 1 - To authenticate the login cookie and renew it
         */
        public void RenewAuthenticatedCookie()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            
            if (authCookie != null & LoginModel.AuthenticatedLogin == true)
            {
                FormsAuthenticationTicket authTicket = null;
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    FormsAuthenticationTicket newAuthTicket = authTicket;
                    if (FormsAuthentication.SlidingExpiration)
                    {
                        newAuthTicket = FormsAuthentication.RenewTicketIfOld(authTicket);
                    }
                    string userData = newAuthTicket.UserData;
                    string[] roles = userData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(newAuthTicket), roles);
                }
            }
        }

        /**
         * Method 2 - Create new Cookie Ticket from login username that is authenticated
         */
        public bool CreateNewTicket(string username) {
            bool goodTicket = false;
            FormsAuthenticationTicket sessionTicket = new FormsAuthenticationTicket(1, username.ToString(), DateTime.Now, DateTime.Now.AddMinutes(60), LoginModel.AuthenticatedLogin, "user");
            string encryptedTicket = FormsAuthentication.Encrypt(sessionTicket);
            HttpCookie newAuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Current.Response.Cookies.Add(newAuthCookie);
            goodTicket = newAuthCookie != null ? true : false;
            return goodTicket;
        }

    }
}