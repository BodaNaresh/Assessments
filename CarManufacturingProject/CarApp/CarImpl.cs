using CarManufacturingProject.Enums;
using CarManufacturingProject.Interfaces;
using CarManufacturingProject.Models;
using CarManufacturingProject.UI;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CarManufacturingProject.CarApp
{
    public class CarImpl: ICarImpl,IEmployeeDetails, IProductDetails,IStockDetails
    {
        EmployeeDetails details = new EmployeeDetails();
        ProductDetails product=new ProductDetails();

        SqlConnection con = new SqlConnection("server=localhost;database=Practice;Integrated Security=true;Encrypt=false");

        public void StartApp()
        {
            Screen.DisplayAppMenu();
            ProcessMenuoption();
        }

        public void ProcessMenuoption()
        {
            int n =int.Parse( Console.ReadLine());
            switch (n)
            {
                case (int)AppMenu.insertEmployeedata:
                insertEmployeedata();
                    break;
                case (int)AppMenu.searchEmployeeData:
                    searchEmployeeData();
                    break;
                case (int)AppMenu.insertProductdata:
                    insertProductdata();
                    break;
                case (int)AppMenu.searchProductData:
                    searchProductData();
                    break;
                case (int)AppMenu.GetStocksList:
                    GetStocksList();
                    break;
                case (int)AppMenu.distribute:
                    distribute();
                    break;
                case (int)AppMenu.ManufacturingandsalesCost:
                    ManufacturingandsalesCost();
                    break;
                default:
                    Console.WriteLine("wrong choice");
                    break;
            }
        }

        
        public void insertEmployeedata()
        {
            try
            {
                Console.WriteLine("Enter name of the Employe ");
                details.E_Name = Console.ReadLine();
                Console.WriteLine("Enter location of the Employe ");
                details.Location = Console.ReadLine();
                Console.WriteLine("Enter salary of Employee ");
                details.Salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter loginhrs ");
                details.loginhrs = int.Parse(Console.ReadLine());

                string query1 = "insert into Employees values('" + details.E_Name + "','" + details.Location + "'," + details.Salary + "," + details.loginhrs + ")";

                SqlCommand cmd = new SqlCommand(query1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data inserted sucessfully");
                FileStream f = new FileStream("d:\\EmployeeDEtails.txt", FileMode.OpenOrCreate);
                StreamWriter s = new StreamWriter(f);
                Console.WriteLine("Writing data to file");
                s.WriteLine("Name:"+details.E_Name);
                s.WriteLine("Location:"+details.Location);
                s.WriteLine("Salary:"+details.Salary);
                s.WriteLine("Loginhrs:"+details.loginhrs);
                s.Close();
                f.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("eneter correct data");
            }
        }
        public void searchEmployeeData()
        {
            try
            {
                Console.WriteLine("Enter enter id");
                details.EId = int.Parse(Console.ReadLine());

                SqlDataAdapter dad = new SqlDataAdapter("sp_EmployeeDept", con);
                DataSet ds = new DataSet();
                dad.Fill(ds, "Employees");
                int data = ds.Tables[0].Rows.Count;
                for (int i = 0; i < data; i++)
                {
                    if (details.EId.ToString() == ds.Tables[0].Rows[i][0].ToString())
                    {
                        Console.WriteLine("Name : " + ds.Tables[0].Rows[i][1].ToString());
                        Console.WriteLine("Location : " + ds.Tables[0].Rows[i][2].ToString());
                        Console.WriteLine("Salary : " + ds.Tables[0].Rows[i][3].ToString());
                        Console.WriteLine("Dept :" + ds.Tables[0].Rows[i][4].ToString());

                    }
                }
                Console.WriteLine("Data Retrieved sucessfully");
            }
            catch (Exception)
            {
                Console.WriteLine("give correct id to search the data");
            }
        }

        public void insertProductdata()
        {
            try
            {
                Console.WriteLine("Enter name of the product ");
                product.P_Name = Console.ReadLine();
                Console.WriteLine("Enter Quantity of product ");
                product.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter size  ");
                product.Size = Console.ReadLine();
                Console.WriteLine("Enter cost  ");
                product.cost= double.Parse(Console.ReadLine());

                string query1 = "insert into Product values('" + product.P_Name + "'," + product.Quantity + ",'" + product.Size + "',"+product.cost+")";

                SqlCommand cmd = new SqlCommand(query1, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data inserted sucessfully");
                FileStream f = new FileStream("d:\\ProductDetails.txt", FileMode.OpenOrCreate);
                StreamWriter s = new StreamWriter(f);
                Console.WriteLine("Writing data to file");
                s.WriteLine("Name:"+product.P_Name);
                s.WriteLine("Quantity:"+product.Quantity);
                s.WriteLine("Size:"+product.Size);
                s.WriteLine("Cost:"+product.cost);
                s.Close();
                f.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("eneter correct data");
            }
        }

        public void searchProductData()
        {
            try
            {
                Console.WriteLine("Enter enter id");
                product.PId = int.Parse(Console.ReadLine());

                SqlDataAdapter dad = new SqlDataAdapter("sp_Productdetails", con);
                DataSet ds = new DataSet();
                dad.Fill(ds, "Product");
                int data = ds.Tables[0].Rows.Count;
                for (int i = 0; i < data; i++)
                {
                    if (product.PId.ToString() == ds.Tables[0].Rows[i][0].ToString())
                    {
                        Console.WriteLine("Name : " + ds.Tables[0].Rows[i][1].ToString());
                        Console.WriteLine("Quantity : " + ds.Tables[0].Rows[i][2].ToString());
                        Console.WriteLine("Size : " + ds.Tables[0].Rows[i][3].ToString());
                        Console.WriteLine("Cost :" + ds.Tables[0].Rows[i][4].ToString());
                    }
                }
                Console.WriteLine("Data Retrieved sucessfully");
            }
            catch (Exception)
            {
                Console.WriteLine("give correct id to search the data");
            }
        }

        public List<StockDetails> GetStocksList()
        {
            List<StockDetails> ret = new List<StockDetails>();
            StockDetails entity;

            try
            {
                entity= new StockDetails();
                SqlCommand cmd = new SqlCommand("select * from Stocks", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("ID " + dr["SId"].ToString());
                    Console.WriteLine("car Name : " + dr["Car_Name"].ToString());
                    Console.WriteLine("showroomlocation : " + dr["ShowroomName"].ToString());
                    Console.WriteLine("price : " + dr["Price"].ToString());
                    Console.WriteLine("milege :" + dr["Milege"].ToString());
                    Console.WriteLine("=================================================");

                }
                dr.Close();
                con.Close();

                Console.WriteLine("Data Retrieved sucessfully");
             

            }
            catch (Exception)
            {
                Console.WriteLine("give correct id to search the data");
            }

            return ret;
           
        }

        public double SalaryDistributionDetails()
        {
          
            if (details.loginhrs >= 8)
            {
                return details.loginhrs + details.Salary*100/30;
            }

            else
            {
                return details.Salary-(details.loginhrs * 500);
            }
                   
            
        }
        public void distribute()
        {
                
                Console.WriteLine("Enter Employee Name : ");
                details.E_Name = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary : ");
                details.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Employee Hours : ");
                details.loginhrs= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------\n");

                 SalaryDetailsdisplay();
                  Console.ReadKey();


        }
        public void SalaryDetailsdisplay()
        {

            Console.WriteLine("Employee Name : " + details.E_Name);
            Console.WriteLine("Employee Salary : " + details.Salary);
            Console.WriteLine("Employee Hours Worked: " + details.loginhrs);
            Console.WriteLine("Total amount to be payed to Employee  : " + SalaryDistributionDetails());
            Console.WriteLine("press 1 for distribute the salary:");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("sucessfully distributed salary for this month:" + " "+   SalaryDistributionDetails());
                    break;
            }
        }


        public void ManufacturingandsalesCost()
        {
            Console.WriteLine("Total salries of employees: ");
            double totalsalaries = double.Parse(Console.ReadLine());
            Console.WriteLine("Total cost of products: ");
            double totalcost = double.Parse(Console.ReadLine());
            Console.WriteLine("enter no of sales");
            double noofsales=double.Parse(Console.ReadLine());
            double totalmufacturingcost = totalsalaries + totalcost;
            Console.WriteLine("the total manufacturing cost is:" + totalmufacturingcost);
            double totalsales = totalcost+noofsales;
            Console.WriteLine("the total sales cost is :" + totalsales);
            
            var mytuple = Tuple.Create(totalsalaries, totalcost, totalmufacturingcost, totalsales);

            PrintTheTotalpurchase(mytuple);

            if (totalmufacturingcost > totalsales)
            {
                Console.WriteLine("loss");
            }
            else
            {
                Console.WriteLine("profit");
            }
        }
       
        static void PrintTheTotalpurchase(Tuple<double, double, double,double> mytuple)
        {
            Console.WriteLine("total salaries: " + mytuple.Item1);
            Console.WriteLine("totalcost: " + mytuple.Item2);
            Console.WriteLine("totalmunufature cost: " + mytuple.Item3);
            Console.WriteLine("totalsales: " + mytuple.Item3);
        }

    }
}
