using System;
using System.Collections.Generic;
using System.Text;

namespace PatientsRegistraion
{
    public interface IPatients
    {
        void DisplayPatientInfo();
        string PatientTotalcost();
        double PatientTotalcost(double admitdate,double dischargedate);
        double PatientTotalcost(double noofDays,double costofbed,double servicecost);
    }
}
