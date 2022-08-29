using Admincommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsRegistraion
{
    public class Patients:CommonInfo,IPatients
    {
        public string Disease;
        public string Address;
        public string Positon;
        public double Mobile;

        public void DisplayPatientInfo()
        {
            Console.WriteLine("id:" + ID + " " + "Name:" + Name + " " + "HospitalName:" + HospitalName+" "+ "Disease"+ Disease+" "+ "Address:"+ Address+" "+ "Positon:"+ Positon+" "+ "Mobile:"+ Mobile);
        }

        public override void Display()
        {
            Console.WriteLine("Endof the patient registration");
        }

        public string PatientTotalcost()
        {
            return "THE TOTAL COST OF THE PATIENT";
        }

        public double PatientTotalcost(double admitdate, double dischargedate)
        {
            double totaldays = admitdate + dischargedate;
            return totaldays;
        }

        public double PatientTotalcost(double noofDays, double costofbed, double servicecost)
        {
            double Totalcost = noofDays + costofbed + servicecost;
            return Totalcost;
        }
    }
}
