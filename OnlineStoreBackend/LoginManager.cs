using System;

namespace OnlineStoreBackend
{
    public class LoginManager
    {
        private IPersistenceManager psm;

        public LoginManager(IPersistenceManager psm)
        {
            this.psm = psm;
        }

        public bool Login(string username, string password)
        {
            return psm.VerifyAccount(username, password);
        }
    }
}