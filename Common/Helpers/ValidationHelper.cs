using System;
using System.Net.Mail;

namespace Common.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                try
                {
                    MailAddress maybeAnEmailAdress = new MailAddress(email);
                }
                catch (FormatException)
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        public static bool IsValidIntegerForId(int integer)
        {
            return integer > 0;
        }
    }
}
