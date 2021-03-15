using System;
using System.Linq;

namespace OnlineStoreBackend
{
    public class RegistrationManager
    {
        public bool RegisterAccount(string username, string password)
        {
            if (username.Length < 3 || username.Length > 10)
            {
                return false;
            }
            else if (!username.All(c => (c >= 'A' && c <= 'Z') ||
                                        (c >= 'a' && c <= 'z') ||
                                        (c >= '0' && c <= '9')))
            {
                return false;
            }
            else if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }
            else if (!password.All(c => (c >= 'A' && c <= 'Z') ||
                                        (c >= 'a' && c <= 'z') ||
                                        (c >= '0' && c <= '9')))
            {
                return false;
            }
            else if (password.ToUpper() == password ||
                     password.ToLower() == password)
            {
                return false;
            }
            return true;
        }
    }
}