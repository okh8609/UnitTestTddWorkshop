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
                try
                {
                    Console.Write("Login or register\r\n-----------------\r\n1. Login\r\n2. Register\r\n=> Choice: ");

                    if (int.Parse(Console.ReadLine()) == 1) // Login
                    {
                        Console.Write("\r\nLogin\r\n-----\r\n");
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        LoginManager lMgr = new LoginManager(new PersistenceManager());
                        if (lMgr.Login(username, password))
                            Console.WriteLine("=> Login successful\r\n");
                        else
                            Console.WriteLine("=> Incorrect username or password\r\n");
                    }
                    else // Register
                    {
                        Console.Write("\r\nRegister\r\n--------\r\n");
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        RegistrationManager regMgr = new RegistrationManager(new PersistenceManager());
                        if (regMgr.RegisterAccount(username, password))
                            Console.WriteLine("=> Registration successful\r\n");
                        else
                            Console.WriteLine("=> Invalid username or password\r\n");
                    }
                }
                catch (Exception)
                {
                    Console.Write("\r\nERROR!\r\n");
                }

            }
        }
    }
}
