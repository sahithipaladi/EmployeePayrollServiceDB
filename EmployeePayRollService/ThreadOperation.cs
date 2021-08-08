using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class ThreadOperations
    {
        //Connecting to database
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=payroll_service;";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool AddEmployee(EmployeeDetails details)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                using (sqlConnection)
                {
                    //Using stored procedure
                    SqlCommand command = new SqlCommand("dbo.InsertIntoTable", this.connection);
                    command.CommandType = CommandType.StoredProcedure;

                    //Adding the parameters
                    command.Parameters.AddWithValue("@Id", details.EmployeeID);
                    command.Parameters.AddWithValue("@Name", details.EmployeeName);
                    command.Parameters.AddWithValue("@BasicPay", details.BasicPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", details.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", details.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", details.Address);
                    command.Parameters.AddWithValue("@Department", details.Department);
                    command.Parameters.AddWithValue("@TaxablePay", details.TaxablePay);
                    command.Parameters.AddWithValue("@Deductions", details.Deductions);
                    command.Parameters.AddWithValue("@NetPay", details.Net_Pay);
                    command.Parameters.AddWithValue("@IncomeTax", details.IncomeTax);
                    this.connection.Open(); //Opening the connection
                    var result = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();//Closing the connection
            }
            return false;
        }

        //Method to add list of employees to DB without thread
        public void AddEmployeeWithoutThread(List<EmployeeDetails> employeeList)
        {
            employeeList.ForEach(employee =>
            {
                Console.WriteLine("Employee being added : " + employee.EmployeeID);
                this.AddEmployee(employee);
                Console.WriteLine("Employee added : " + employee.EmployeeID);
            });
        }

        //Method to add list of employees to DB with thread
        public void AddEmployeeWithThread(List<EmployeeDetails> employeeList)
        {
            employeeList.ForEach(employee =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Employee being added : " + employee.EmployeeID);
                    this.AddEmployee(employee);
                    Console.WriteLine("Employee added : " + employee.EmployeeID);
                });
                thread.Start();
                thread.Join();
            });
        }
    }
}
