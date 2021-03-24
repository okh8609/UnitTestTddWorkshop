using OnlineStoreBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreBackend.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                RegistrationManager regMgr = new RegistrationManager(new PersistenceManager());
                if (regMgr.RegisterAccount(username, password))
                    Console.WriteLine("Registration succeeded.");
                else
                    Console.WriteLine("Registration failed.");
            }
        }
    }
}
