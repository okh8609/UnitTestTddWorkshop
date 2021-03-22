using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace OnlineStoreBackend
{
    public class RegistrationManager
    {
        private IPersistenceManager psm;

        public RegistrationManager(IPersistenceManager psm)
        {
            this.psm = psm;
        }

        public bool RegisterAccount(string username, string password)
        {
            Regex regex = new Regex("^[A-Za-z0-9]{3,10}$");
            if (!regex.IsMatch(username))
                return false;

            regex = new Regex("^[A-Za-z0-9]{6,10}$");
            if (!regex.IsMatch(password))
                return false;

            Regex rgx1 = new Regex("[A-Z]");
            Regex rgx2 = new Regex("[a-z]");
            Regex rgx3 = new Regex("[0-9]");
            if (!rgx1.IsMatch(password) || !rgx2.IsMatch(password) || !rgx3.IsMatch(password))
                return false;

            if (psm.CheckUsernameExists(username) == true)
                return false;

            psm.SaveAccount(username, password);

            return true;

        }
    }
}