using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.ComponentModel;

namespace MulderbertPX.Models
{
    /// <summary>
    /// Class Definition: DataProcessing Class is for handling the dataprocessing requirements using the DAO for base class access
    /// </summary>
    public class DataProcessing:DAO
    {
        //declare class variables/objects
        SqlCommand Cmd { get; set; }//For Customer Table
        HashTable HashSensitiveField { get; set; }
        public static CustomerModel activeCustomer = new CustomerModel(); //when logged in
        /**
         * Method 1 - AddNewUser() is adding customer information upon registration to User and Customer tables in DB mulderbertpx_db (V2.0)
         */
        public bool AddNewUser(CustomerModel newCustomer)
        {
            //local declarations/initialisatiosn
            HashSensitiveField = new HashTable();
            string password = HashSensitiveField.EncryptPassword(newCustomer.Password.ToString());
            //string country = newCustomer.Country.ToString();
            bool newUserConfirmed = false;
            //routine
            try
            {
                //check fields for nulls and create default inputs for database
                if (newCustomer.City == null) { newCustomer.City = "Unknown Value"; }
                if (newCustomer.CompanyName == null) { newCustomer.CompanyName = "Unknown Value"; }
                if (newCustomer.CompanyNumber == null) { newCustomer.CompanyNumber = "Unknown Value"; }
                if (newCustomer.TaxVatNumber == null) { newCustomer.TaxVatNumber = "Unknown Value"; }
                //load data from object and call usp in db
                Cmd = new SqlCommand("uspAddNewCustomer", OpenConnection()); 
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@username", newCustomer.Username.ToString());//For User Table
                Cmd.Parameters.AddWithValue("@passwordsha", password);
                Cmd.Parameters.AddWithValue("@companyName", newCustomer.CompanyName.ToString());//For Customer Table
                Cmd.Parameters.AddWithValue("@contactFirstName", newCustomer.ContactFirstName.ToString());
                Cmd.Parameters.AddWithValue("@contactLastName", newCustomer.ContactLastName.ToString());
                Cmd.Parameters.AddWithValue("@streetAddress", newCustomer.AddressLine1.ToString());
                Cmd.Parameters.AddWithValue("@area", newCustomer.AddressLine2.ToString());
                Cmd.Parameters.AddWithValue("@city", newCustomer.City.ToString());
                Cmd.Parameters.AddWithValue("@country", newCustomer.Country.ToString());
                Cmd.Parameters.AddWithValue("@postCode", newCustomer.PostCode.ToString());
                Cmd.Parameters.AddWithValue("@email", newCustomer.Email.ToString());
                Cmd.Parameters.AddWithValue("@contactNumber", newCustomer.ContactNumber.ToString());
                Cmd.Parameters.AddWithValue("@companyNumber", newCustomer.CompanyNumber.ToString());
                Cmd.Parameters.AddWithValue("@taxVatNumber", newCustomer.TaxVatNumber.ToString());
                Cmd.Parameters.AddWithValue("@customerType", newCustomer.CustomerType.ToString());
                Cmd.Parameters.AddWithValue("@paymentTerms", newCustomer.PaymentTerms.ToString());
                Cmd.Parameters.AddWithValue("@termsCustomerAcceptance", newCustomer.TermsAndConditionsOk.ToString());
                Cmd.Parameters.AddWithValue("@registrationDate", DateTime.Now);
                int newUserAdded = Cmd.ExecuteNonQuery();
                if (newUserAdded == 0)
                {
                    Console.WriteLine("Database Insert Request Failed - Returned as Unsuccessful to DataProcessing() class");
                }
                else
                {
                    newUserConfirmed = true;
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine("Database write from DataProcessing() class threw an exception, please note SQL Exception Details: " + se.Message);
            }
            catch (NullReferenceException nr)
            {
                Console.WriteLine("Database write from DataProcessing() class threw a nullreference pointer due to fields returning null from the data object");
                Console.WriteLine("Please note SQL Exception Details: " + nr.Message);
                newCustomer.CompanyName = "Not Supplied";
            }
            finally
            {
                CloseConnection();
            }
            return newUserConfirmed;
        }
        /**
        * Method 2 - checking login details against database and returning boolean result
        */
        public bool CheckLogin(LoginModel login)
        {
            //vars/objs
            bool validLogin = false;
            HashSensitiveField = new HashTable();
            String password = HashSensitiveField.EncryptPassword(login.Password.ToString());
            //routine
            try
            {
                Cmd = new SqlCommand("uspCheckCreds", OpenConnection());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@username", login.Username.ToString());
                Cmd.Parameters.AddWithValue("@passwordsha", password);
                SqlDataReader dataReader = Cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    validLogin = true;
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                CloseConnection();
            }
            return validLogin;
        }
        /**
         * Method 3 - GetCustomerID() gets customerID from logged in customer username match at DB level
         */
        public int GetCustomerID(string userName) {
            int customerID = 0;
            try
            {
                Cmd = OpenConnection().CreateCommand();
                Cmd.CommandText = "uspGetCustomerID";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@username", userName);
                SqlDataReader dataReader = Cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    customerID = dataReader.GetInt32(0);
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                CloseConnection();
            }
            return customerID;
        }
        /**
         * Method 4 - AddNewOrder() adds a new order from product view
         */
        public bool AddNewOrder(string orderType, string productName,
            string productDescription, int unitPrice, int netTotal, double tax, 
            double orderTotal, string unitQuantity, string billingStatus, int customerID)
        {
            bool orderAdded = false;
            try
            {
                if (netTotal > 0)
                {
                    Cmd = new SqlCommand("uspAddNewOrder", OpenConnection());
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@orderType", orderType);
                    Cmd.Parameters.AddWithValue("@productName", productName);
                    Cmd.Parameters.AddWithValue("@productDescription", productDescription);
                    Cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                    Cmd.Parameters.AddWithValue("@netTotal", netTotal);
                    Cmd.Parameters.AddWithValue("@tax", tax);
                    Cmd.Parameters.AddWithValue("@orderTotal", orderTotal);
                    Cmd.Parameters.AddWithValue("@unitQuantity", unitQuantity);
                    Cmd.Parameters.AddWithValue("@billingStatus", billingStatus);
                    Cmd.Parameters.AddWithValue("@customerID", customerID);
                    int result = Cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        Console.WriteLine("Transaction / Sale Insert to DB Failed - Returned as Unsuccessful to DataProcessing() class");
                    }
                    else
                    {
                        orderAdded = true;
                    }
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                CloseConnection();
            }
            return orderAdded;
        }
    }
}