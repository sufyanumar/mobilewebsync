
﻿using System.Text.RegularExpressions;

namespace ApexChat.Helpers.Extensions
{
    public static class ExtensionMethods
    {
        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }
        public static string GetEmailFromHtml(string messagetext)
        {
            string pattern = "(<a href=)(.*)(</a>)";
            if (!string.IsNullOrWhiteSpace(messagetext) && Regex.IsMatch(messagetext, pattern))
            {
                var extractedEmail = messagetext.Substring(messagetext.IndexOf(">") + 1, messagetext.IndexOf("</a>") - messagetext.IndexOf(">") - 1);
                if (!string.IsNullOrEmpty(extractedEmail) && IsValidEmail(extractedEmail))
                {
                    string replaced = Regex.Replace(messagetext, pattern, extractedEmail);
                    messagetext = replaced;
                }
            }
            return messagetext;
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
