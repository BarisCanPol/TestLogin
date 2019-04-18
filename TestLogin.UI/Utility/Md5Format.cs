using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TestLogin.UI.Utility
{
    public class Md5Format
    {
        public static string EncMD5(string password)
        {
            if (password != null)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] array = Encoding.UTF8.GetBytes(password);
                array = md5.ComputeHash(array);
                StringBuilder sb = new StringBuilder();

                foreach (byte ba in array)
                {
                    sb.Append(ba.ToString("x2").ToLower());

                }
                return sb.ToString();
            }
            else
            {
                return password;
            }
                                      
        }
    }
}