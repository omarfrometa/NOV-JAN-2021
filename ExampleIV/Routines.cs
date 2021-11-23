using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleIV
{
    public static class Routines
    {
        public static string FormatPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return phone;
            }

            if (phone.Length == 10)
            {
                return $"({phone.Substring(0, 3)}) {phone.Substring(3, 3)}-{phone.Substring(6)}";
            }

            return phone;
        }
    }
}