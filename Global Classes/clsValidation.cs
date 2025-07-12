using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD1
{
    public class clsValidation
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3,}$";
            return Regex.IsMatch(email, pattern);
        }
        public static bool IsValidPhone(string phone)
        {
            string pattern = @"^(010|011|012|015)\d{8}$";
            return Regex.IsMatch(phone, pattern);

            /*
            if (!string.IsNullOrWhiteSpace(phone)
                && phone.Length == 11
                && phone.All(char.IsDigit)
                && (phone.StartsWith("010")
                   || phone.StartsWith("011")
                   || phone.StartsWith("012")
                   || phone.StartsWith("015")))
                return true;
            else
                return false;
            */
        }
        public static bool IsNationalNo(string nationalNo)
        {
            string pattern = @"^\d{14}$";
            return Regex.IsMatch(nationalNo, pattern);

            /*
            if (!string.IsNullOrWhiteSpace(nationalNo)
                && !string.IsNullOrEmpty(nationalNo)
                && nationalNo.Length == 14
                && nationalNo.All(char.IsDigit))
                return true;
            else
                return false;
            */
        }
    }
}
