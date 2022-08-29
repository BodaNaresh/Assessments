using System;
using System.Collections.Generic;
using System.Text;

namespace Admincommon
{
    public abstract class CommonInfo
    {
        public int ID;
        public string Name;
        public string HospitalName;

        public abstract void Display(); 
        public void Welcome()
        {
            Console.WriteLine("Welcome to the Hospital registraion to enter the Details to continue.... ");
        }
    }
}
