using Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Franchise_registration
{
    public class f_reg:If_reg
    {
        public int fcode { get; set; }
        public string fName { get; set; }
        public string location { get; set; }
        public double rent { get; set; }
        public int totalsales { get; set; }
        public int totalemp { get; set; }
        public string Dates { get; set; }


        SqlConnection con = new SqlConnection("server=localhost;database=Practice;Integrated Security=true;Encrypt=false");

        public void insertData()
        {
            try
            {

                Console.WriteLine("Enter name of the franchisee ");
                fName = Console.ReadLine();
                Console.WriteLine("Enter the location of franchisee ");
                location = Console.ReadLine();
                Console.WriteLine("Enter the rent of franchisee ");
                rent = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter total sales done by franchisee id ");
                totalsales = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter total emp of the franchisee ");
                totalemp = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter date in yyyy/mm/dd format ");

                Dates = DateTime.Now.ToString(Console.ReadLine());
               


                string query1 = "insert into Franchise values('" + fName + "','" + location + "'," + rent + " ," + totalsales + "," + totalemp + ",'" + Dates + "')";

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


                Console.WriteLine("Enter enter fcode to search the franchisee by id");
                fcode = int.Parse(Console.ReadLine());

                SqlDataAdapter dad = new SqlDataAdapter("sp_franchise", con);
                DataSet ds = new DataSet();
                dad.Fill(ds, "Franchise");
                int data = ds.Tables[0].Rows.Count;
                for (int i = 0; i < data; i++)
                {
                    if (fcode.ToString() == ds.Tables[0].Rows[i][0].ToString())
                    {
                        Console.WriteLine("franchisename : " + ds.Tables[0].Rows[i][1].ToString());
                        Console.WriteLine("Date : " + ds.Tables[0].Rows[i][2].ToString());
                        Console.WriteLine("Totalsales : " + ds.Tables[0].Rows[i][3].ToString());
                        Console.WriteLine("location :" + ds.Tables[0].Rows[i][4].ToString());


                    }

                }
                Console.WriteLine("Data Retrieved sucessfully");
            }


            catch (Exception)
            {
                Console.WriteLine("give correct id to search the data");
            }

           

        }
        public void deleteData()
        {
            try
            {
                Console.WriteLine("Enter id of the franchise to be delete ");
                fcode = int.Parse(Console.ReadLine());
                string query1 = "delete from Franchise where fcode=" + fcode + "";

                SqlCommand cmd1 = new SqlCommand(query1, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data deleted sucessfully");
            }
            catch (Exception)
            {
                Console.WriteLine("eneter correct id");
            }
        }

    }
}
