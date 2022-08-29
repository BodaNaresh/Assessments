using BedInfo;
using DoctorsRegistration;
using PatientsRegistraion;
using System;

namespace HospitalManagementProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press 1 for to enter the Doctors data ");
            Console.WriteLine("press 2 for to enter the Patients data ");
            Console.WriteLine("press 3 for to enter the Beds details ");

            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    Console.WriteLine("registration of the doctors");
                    Doctors doctors = new Doctors();
                    doctors.Welcome();
                    Console.WriteLine("Enter the id,name,Hospitalname,Department,Qualification,salary ");
                    doctors.ID = int.Parse(Console.ReadLine());
                    doctors.Name = Console.ReadLine();
                    doctors.HospitalName = Console.ReadLine();
                    doctors.Department = Console.ReadLine();
                    doctors.Qualification = Console.ReadLine();
                    doctors.Salary= double.Parse(Console.ReadLine());
                    doctors.DispalyDoctorsInfo();

                    Console.Write("Enter the doctors fee structure fee,sal,pf ");
                    double fees = double.Parse(Console.ReadLine());
                    double salry = double.Parse(Console.ReadLine());
                    double pf = double.Parse(Console.ReadLine());
                    double totalfee = doctors.DoctorsFee(fees,salry,pf);
                    Console.WriteLine("total fee of the doctor:" + totalfee);
                    doctors.Display();

                    break;

                case 2:
                    Console.WriteLine("registration of the patients");
                    Patients patient = new Patients();
                    patient.Welcome();
                    Console.WriteLine("Enter the id,name,address,Disease,Hospitalname,position,mobile ");
                    patient.ID = int.Parse(Console.ReadLine());
                    patient.Name = Console.ReadLine();
                    patient.Disease = Console.ReadLine();
                    patient.Address = Console.ReadLine();
                    patient.HospitalName = Console.ReadLine();
                    patient.Positon = Console.ReadLine();
                    patient.Mobile = double.Parse(Console.ReadLine());

                    patient.DisplayPatientInfo();

                    Console.Write("Enter the fee structure payed by patient  ");
                    Console.WriteLine(patient.PatientTotalcost());
                    Console.WriteLine("Enter the from nodays To Noof days");
                    double day = double.Parse(Console.ReadLine());
                    double day1 = double.Parse(Console.ReadLine());
                    double totalday = patient.PatientTotalcost(day,day1);
                    Console.WriteLine("total days of the patient:" + totalday);
                    Console.WriteLine("enter the structure of fee noofdays,cost of bed,servicecost");
                    double d = double.Parse(Console.ReadLine());
                    double d1 = double.Parse(Console.ReadLine());
                    double d2 = double.Parse(Console.ReadLine());
                    double totalstructure = patient.PatientTotalcost(d, d1,d2);
                    Console.WriteLine("total fee of the patient:" + totalstructure);

                    patient.Display();

                    break;

                case 3:
                    Console.WriteLine("booking beds in hospital");
                    BedsInfo bed = new BedsInfo();
                    bed.Welcome();
                    Console.WriteLine("Enter the id,name,Hospitalname,bedno,allotment ");
                    bed.ID = int.Parse(Console.ReadLine());
                    bed.Name = Console.ReadLine();
                    bed.HospitalName = Console.ReadLine();
                    bed.BedNo = int.Parse(Console.ReadLine());
                    bed.Allotment = Console.ReadLine();

                    bed.DispalyBedsInfo();

                    Console.WriteLine("Enter the bed cost such as bedcost and numofdays");
                    double b = double.Parse(Console.ReadLine());
                    double b1 = double.Parse(Console.ReadLine());
                    double totalbed = bed.DisplayBedcost(b, b1);
                    Console.WriteLine("total beds of the patients:" + totalbed);
                    bed.Display();
                    break;

                default:
                    Console.WriteLine("wrong data choice");
                    break;
            }
        }
    }
}
