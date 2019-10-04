using System;
using System.Net.Mail;

namespace Common.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
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

        public static bool IsValidIntegerForId(int integer)
        {
            return integer > 0;
        }
    }
}
