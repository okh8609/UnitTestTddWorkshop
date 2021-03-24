using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBackend
{
    public class PersistenceManager : IPersistenceManager
    {
        public PersistenceManager()
        {
            if (!File.Exists("Accounts.ini"))
                File.Create("Accounts.ini").Close();
        }

        public bool CheckUsernameExists(string username)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("Accounts.ini", Encoding.UTF8);
            if (data["Accounts"][username] != null)
                return true;
            return false;
        }

        public void SaveAccount(string username, string password)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("Accounts.ini", Encoding.UTF8);
            data["Accounts"][username] = password;
            parser.WriteFile("Accounts.ini", data, Encoding.UTF8);
        }

        public bool VerifyAccount(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
