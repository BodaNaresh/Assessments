using Employeereg;
using Franchise_registration;
using Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FranchiseLogin
{
    public class Franchise:IFranchise
    {
        public int fid { get; set; }
        public string funiqueID { get; set; }
        public string password { get; set; }

        SqlConnection con = new SqlConnection("server=localhost;database=Practice;Integrated Security=true;Encrypt=false");

        f_reg re = new f_reg();
        public void insertcredentials()
        {
            Console.WriteLine("enter the Franchise credentials to login");
            funiqueID = Console.ReadLine();
            password = Console.ReadLine();

            string query = "select * from FranchiseLogin";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "FranchiseLogin");
            int data = ds.Tables[0].Rows.Count;

           
            for (int i = 0; i < data; i++)
            {
                if (funiqueID.ToString() == ds.Tables[0].Rows[i][1].ToString() && password.ToString() == ds.Tables[0].Rows[i][2].ToString())
                {
                    re.insertData();
                }
            }
        }
        
        public void Searchcredentials()
        {
            Console.WriteLine("enter the Franchise credentials to login");
            funiqueID = Console.ReadLine();
            password = Console.ReadLine();

            string query = "select * from FranchiseLogin";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "FranchiseLogin");
            int data = ds.Tables[0].Rows.Count;


            for (int i = 0; i < data; i++)
            {
                if (funiqueID.ToString() == ds.Tables[0].Rows[i][1].ToString() && password.ToString() == ds.Tables[0].Rows[i][2].ToString())
                {
                    re.searchData();
                }
            }
        }
       
       
    }
}
