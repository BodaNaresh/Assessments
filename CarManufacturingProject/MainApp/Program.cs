using CarManufacturingProject.CarApp;
using CarManufacturingProject.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarManufacturingProject.MainApp
{
    public class Program
    {
       
        public  static void chechusernameandpassword()
        {
            AdminCredentials admin = new AdminCredentials();
            CarImpl app = new CarImpl();
            string answer = "Y";
            Console.WriteLine("=======================Welcome to carmanufaturing unit====================");
            Console.WriteLine("Enter your registered username and password to login.....");
            admin.username = Console.ReadLine();
            admin.password = Console.ReadLine();

            List<AdminCredentials> credentials = new List<AdminCredentials>
            {
                new AdminCredentials{username="Naresh",password="123"},
                new AdminCredentials{username="Hari",password="111"},
            };
            foreach (var login in credentials)
            {
                if (admin.username.ToString() == login.username && admin.password.ToString() == login.password)
                {
                    
                    while (answer.ToUpper() == "Y")
                    {
                        app.StartApp();

                        Console.WriteLine("do you want to continue Y/N:");
                        answer = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("wrong credentials");
                }
            }
        }
        static void Main(string[] args)
        {
            chechusernameandpassword();

        }
    }
}
