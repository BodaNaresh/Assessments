using Adminlogin;
using Employeereg;
using Franchise_registration;
using FranchiseLogin;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace FranchiseProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("server=localhost;database=Practice;Integrated Security=true;Encrypt=false");
            
            Franchise franch = new Franchise();

            string answer = "Y";
            admin ad = new admin();
            emp_reg reg = new emp_reg();
            f_reg fr = new f_reg();

            Console.WriteLine("Welcome to pizzastore");
            Console.WriteLine("Enter your registered username and password to login.....");
            ad.username = Console.ReadLine();
            ad.password = Console.ReadLine();

            string query = "select * from AdminLogin";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "AdminLogin");
            int data = ds.Tables[0].Rows.Count;



            for(int i = 0; i < data; i++)
            {
                if (ad.username.ToString() == ds.Tables[0].Rows[i][1].ToString() && ad.password.ToString() == ds.Tables[0].Rows[i][2].ToString())
                {

                    while (answer.ToUpper() == "Y")
                    {
                        Console.WriteLine("Enter your choice:press 1 for register the franchise");
                        Console.WriteLine("press 2 for search franchise details");
                        Console.WriteLine("press 3 insert employee details");
                        Console.WriteLine("press 4 search the employee sales details");
                        Console.WriteLine("press 5 for the sales record and salry info");
                        Console.WriteLine("press 6 for delete franchise");
                        int n = int.Parse(Console.ReadLine());

                        switch (n)
                        {
                            case 1:
                                franch.insertcredentials();
                                break;
                            case 2:
                                franch.Searchcredentials();
                                break;
                            case 3:
                                reg.insertData();
                                break;
                            case 4:
                                reg.searchData();
                                break;
                            case 5:
                                reg.salesrecord();
                                break;
                            case 6:
                                fr.deleteData();
                                break;
                            default:
                                Console.WriteLine("wrong data choice");
                                break;
                        }

                        Console.WriteLine("do you want to continue Y/N:");
                        answer = Console.ReadLine();
                    }
                }
            }
        }

        
    }
}
