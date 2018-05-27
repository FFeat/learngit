using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.Common
{
    public static class Encryption
    {
        public static string GetPwsMd5(string pwd)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(pwd);
            MD5CryptoServiceProvider mt = new MD5CryptoServiceProvider();
            byte[] bts = mt.ComputeHash(buffer);
            string str = "";
            for (int i = 0; i < bts.Length; i++)
            {
                str += bts[i].ToString("x2");

            }
            return str;
        }
    }
}
