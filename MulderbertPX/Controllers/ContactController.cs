using MulderbertPX.Models;
using System;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace MulderbertPX.Controllers
{
    /// <summary>
    /// Class Definition: Controller class managing Contact Us view data flow to back end
    /// </summary>
    public class ContactController : Controller
    {
        /**
         * Class Object and Variable Declarations
         */
        private string filePath = @"~/App_Data/contactus.xml";

        //initial page authentication using constructor
        public ContactController()
        {
            if (LoginModel.AuthenticatedLogin == true)
            {
                new LoginAuthentication().RenewAuthenticatedCookie();
            }
        }
        /*
         * Method 1 - Main View for class
         */
        public ActionResult Index()
        {
            return View("Index");
        }
        /**
         * Method 2 - Action Method to to process the submission of the contact us form. 
         */
        public ActionResult SubmitEntry(ContactModel model)
        {
            if (WriteToXMLDB(model))
            {
                return View("SubmitEntry", model);
            }
            else
            {
                return View("Index");
            }
        }

        /**
         * Helper Method 1 - Create XML file path or read from XML file into memory 
         */
        private bool WriteToXMLDB(ContactModel contact)
        {
            bool isValid = false;
            if (System.IO.File.Exists(Server.MapPath(filePath)) && contact.Email != null)
            {
                if (ModelState.IsValid)
                {
                    isValid = AddToXMLDB(contact);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    isValid = AddFirstEntryToXMLDB(contact);
                }
            }
            return isValid;
        }
        /**
         * Helper Method 2 - AddFirstEntryToXMLDB(ContactModel contact) - Add Contact Us entry to the XML DB File
         */
        public bool AddFirstEntryToXMLDB(ContactModel contact)
        {
            bool validFile = false;
            try
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(Server.MapPath(filePath)))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Contactus");
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
                //load contact us entry details on first submission
                XDocument contactUs = XDocument.Load(Server.MapPath(filePath));
                XElement contactEntry = contactUs.Element("Contactus");
                contactEntry.Add(
                    new XElement("ContactEntry",
                    new XElement("ContactDate", DateTime.Now),
                    new XElement("FirstName", contact.FirstName),
                    new XElement("LastName", contact.LastName),
                    new XElement("Phone", contact.Phone),
                    new XElement("Email", contact.Email),
                    new XElement("ContactType", contact.ContactClass.ToString()),
                    new XElement("AccountReference", contact.AccountNumber),
                    new XElement("Request", contact.Request)));
                contactUs.Save(Server.MapPath(filePath));
                validFile = true;
            }
            catch (Exception e)
            {
                ViewBag.Message = "Contact Write to DB (XML) went wrong. Details are " + e.Message;
                Console.WriteLine("Contact Controller - Details: " + e.Message);
            }
            return validFile;
        }
        /**
         * Helper Method 3 - AddToXMLDB(ContactModel contact) - Add Contact Us entry to the XML DB File (Dev Note: adding dynamically using LINQ)
         */
        public bool AddToXMLDB(ContactModel contact)
        {
            bool validFile = false;
            try
            {
                XDocument contactUs = XDocument.Load(Server.MapPath(filePath));
                XElement contactEntry = contactUs.Element("Contactus");
                contactEntry.Add(

                    new XElement("ContactEntry",
                    new XElement("ContactDate", DateTime.Now),
                    new XElement("FirstName", contact.FirstName),
                    new XElement("LastName", contact.LastName),
                    new XElement("Phone", contact.Phone),
                    new XElement("Email", contact.Email),
                    new XElement("ContactType", contact.ContactClass.ToString()),
                    new XElement("AccountReference", contact.AccountNumber),
                    new XElement("Request", contact.Request)));
                contactUs.Save(Server.MapPath(filePath));
                validFile = true;
                if (validFile)
                {
                    ViewBag.Message = "Contact Submission Successfully Added";
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "Contact Write to DB (XML) went wrong. Details are " + e.Message;
                Console.WriteLine("Contact Controller - Details: " + e.Message);
            }
            return validFile;
        }
    }
}