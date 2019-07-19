using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Core
{
    class EncrpDec
    {
        public static string DecodeBase64(string Base64String)
        {
            string Decodestring = Base64String;
            Decodestring = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Decodestring));
            return Decodestring;
        }
        public static string EncodeBase64(string value)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(value);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
