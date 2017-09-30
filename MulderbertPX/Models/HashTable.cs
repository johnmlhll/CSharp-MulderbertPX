using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace MulderbertPX.Models
{
    class HashTable
    {
        //class definition: Implement Password Encription with SHA1
        public string EncryptPassword(string data)
        {
            StringBuilder returnValue = new StringBuilder();
            try
            {
                SHA1 sha = SHA1.Create();
                byte[] hashdata = sha.ComputeHash(Encoding.Default.GetBytes(data));
                for (int i = 0; i < hashdata.Length; i++)
                {
                    returnValue.Append(hashdata[i].ToString());
                }
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine(ae.Message);
            }
            return returnValue.ToString();
        }
    }
}