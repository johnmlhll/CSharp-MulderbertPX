using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MulderbertPX;
using MulderbertPX.Controllers;
using MulderbertPX.Models;

namespace MulderbertPX.Tests.Controllers
{
    /// <summary>
    /// Class Definition: Test Class for the Home Controller class
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        //Start Tests checking if controllers for application for working at a basic view level
        /**
          * Method 1 - Test Controller from HomeController Class
          */
        [TestMethod]
        public void HomeControllerTestStart()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        /**
          * Method 2 - Test Controller from AboutUsController Class
          */
        [TestMethod]
        public void AboutUsControllerTest()
        {
            // Arrange
            AboutUsController aboutUs = new AboutUsController();

            // Act
            ViewResult aboutResult = aboutUs.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(aboutResult);

        }
        /**
          * Method 3 - Test Controller from ContactController Class
          */
        [TestMethod]
        public void ContactControllerTest()
        {
            ContactController contact = new ContactController();

            ViewResult contactResult = contact.Index() as ViewResult;

            Assert.IsNotNull(contactResult);

        }
        /**
          * Method 4 - Test Controller from ContactController Class
          */
        [TestMethod]
        public void LoginControllerTest()
        {
            LoginController login = new LoginController();

            ViewResult loginResult = login.Index() as ViewResult;

            Assert.IsNotNull(loginResult);
        }

        /**
         * Method 5 - Test Controller from ContactController Class
         */
        [TestMethod]
        public void ProductRangeControllerTest()
        {
            ProductRangeController product = new ProductRangeController();

            ViewResult productResult = product.Index() as ViewResult;

            Assert.IsNotNull(productResult);
        }
        /**
          * Method 6 - Test Controller from ContactController Class
          */
        [TestMethod]
        public void ProductServiceControllerTest()
        {
            ProductServiceController service = new ProductServiceController();

            ViewResult serviceResult = service.Index() as ViewResult;

            Assert.IsNotNull(serviceResult);
        }

        /**
         * Method 7 - Test Controller from RegistrationController Class
         */
        [TestMethod]
        public void RegistrationControllerTest()
        {
            RegistrationController registration = new RegistrationController();

            ViewResult registrationResult = registration.Index() as ViewResult;

            Assert.IsNotNull(registrationResult);
        }

        /**
         * Method 8 - Test Controller from SiteMapController Class
         */
        [TestMethod]
        public void SiteMapControllerTest()
        {
            SiteMapController sitemap = new SiteMapController();

            ViewResult sitemapResult = sitemap.Index() as ViewResult;

            Assert.IsNotNull(sitemapResult);
        }
        //End of tests checking that Application Controllers are actually working
    }
}
