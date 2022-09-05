using Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Employeereg
{

    public class emp_reg:Iemp_reg
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double SalaryDistribution { get; set; }
        public double Mobile { get; set; }
        public string Saletype { get; set; }
        public int fcode { get; set; }


        SqlConnection con = new SqlConnection("server=localhost;database=Practice;Integrated Security=true;Encrypt=false");

        public void insertData()
        {
            try
            {

                Console.WriteLine("Enter name of the employee ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter salary distribution for the employee ");
                SalaryDistribution = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter mobile no of employee ");
                Mobile = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter sale type which emp saled in offline/online  ");
                Saletype = Console.ReadLine();
                Console.WriteLine("Enter fcode to assign the employee ");
                fcode = int.Parse(Console.ReadLine());

                string query1 = "insert into Employee_franchise values('" + Name + "'," + SalaryDistribution + "," + Mobile + " ,'" + Saletype + "',"+fcode+")";

                SqlCommand cmd = new SqlCommand(query1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data inserted sucessfully");
            }
            catch (Exception)
            {
                Console.WriteLine("eneter correct data");
            }

        }

        public void searchData()
        {
            try
            {


                Console.WriteLine("Enter enter id of employee");
                id = int.Parse(Console.ReadLine());

                SqlDataAdapter dad = new SqlDataAdapter("sp_Employee", con);
                DataSet ds = new DataSet();
                dad.Fill(ds, "Employee_franchise");
                int data = ds.Tables[0].Rows.Count;
                for (int i = 0; i < data; i++)
                {
                    if (id.ToString() == ds.Tables[0].Rows[i][0].ToString())
                    {
                        Console.WriteLine("Name : " + ds.Tables[0].Rows[i][1].ToString());
                        Console.WriteLine("Mobile : " + ds.Tables[0].Rows[i][2].ToString());
                        Console.WriteLine("location : " + ds.Tables[0].Rows[i][3].ToString());
                        Console.WriteLine("salestype : " + ds.Tables[0].Rows[i][4].ToString());
                        Console.WriteLine("totalsales : " + ds.Tables[0].Rows[i][5].ToString());


                    }

                }
                Console.WriteLine("Data Retrieved sucessfully");
            }


            catch (Exception)
            {
                Console.WriteLine("give correct id to search the data");
            }
        }

        public void salesrecord()
        {
            Console.WriteLine("Enter enter id of employee to see the salary distribution and sales record");
            id = int.Parse(Console.ReadLine());
            string query = "sp_salesrecordSalarydistribute";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee_franchise");
            int data = ds.Tables[0].Rows.Count;


            for (int i = 0; i < data; i++)
            {
                if (id.ToString() == ds.Tables[0].Rows[i][0].ToString())
                {
                    Console.WriteLine("Name : " + ds.Tables[0].Rows[i][1].ToString());
                    Console.WriteLine("salarydistribution : " + ds.Tables[0].Rows[i][2].ToString());
                    Console.WriteLine("dateofdistribution : " + ds.Tables[0].Rows[i][3].ToString());
                    Console.WriteLine("salestype :" + ds.Tables[0].Rows[i][4].ToString());
                    Console.WriteLine("totalsales :" + ds.Tables[0].Rows[i][5].ToString());
                }
            }
        }

        
    }
}
