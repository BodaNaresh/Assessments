using Admincommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorsRegistration
{
    public class Doctors:CommonInfo,IDoctors
    {
        public string Department;
        public string Qualification;
        public double Salary;

        public void DispalyDoctorsInfo()
        {
            Console.WriteLine("id:" + ID + " " + "Name:" + Name + " " + "HospitalName:" + HospitalName+" "+ "Department"+ Department+" "+ "Qualification: " +Qualification+" "+ "Salary:"+ Salary);
        }

        public double DoctorsFee(double fee, double sal, double pf)
        {
            double Totalsal = fee + sal * pf;
            return Totalsal;
        }


        public override void Display()
        {
            Console.WriteLine("Endof the Doctors registration");
        }
    }
}
