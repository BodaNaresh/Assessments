using Admincommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace BedInfo
{
    public class BedsInfo:CommonInfo,IBedsInfo
    {
        public int  BedNo;
        public string Allotment;

        public void DispalyBedsInfo()
        {
            Console.WriteLine("id:" + ID + " " + "Name:" + Name + " " + "HospitalName" + HospitalName + " " + "BedNo" + BedNo + " " + "Allotment:" + Allotment);
        }

        public double DisplayBedcost(double bedcost, double num)
        {
            double totalbedcost = bedcost * num ;
            return totalbedcost;
        }

        public override void Display()
        {
            Console.WriteLine("Endof the Beds info registration");
        }
    }
}
