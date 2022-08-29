using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorsRegistration
{
    public interface IDoctors
    {
        void DispalyDoctorsInfo();
        double DoctorsFee(double fee, double sal, double pf);
    }
}
