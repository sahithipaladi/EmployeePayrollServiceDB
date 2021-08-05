using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeePayrollService
{
    public class EmployeeRepository
    {
        //Connecting to database
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service;";

        SqlConnection connection = new SqlConnection(connectionString);

        public void GetAllEmployee()
        {
            try
            {
                EmployeeDetails details = new EmployeeDetails();
                using (this.connection)
                {
                    //Query to perfom
                    string query = @"Select * from employee_payroll";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open(); //Opening the connection
                    SqlDataReader dataReader = command.ExecuteReader();
                    //Checking if the table has data
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            details.EmployeeID = Convert.ToInt32(dataReader["id"]);
                            details.EmployeeName = dataReader["name"].ToString();
                            details.BasicPay = Convert.ToDouble(dataReader["basic_pay"]);
                            details.StartDate = dataReader.GetDateTime(3);
                            details.Gender = dataReader["gender"].ToString();
                            details.PhoneNumber = dataReader["phonenumber"].ToString();
                            details.Address = dataReader["address"].ToString();
                            details.Department = dataReader["department"].ToString();
                            details.Deductions = Convert.ToDouble(dataReader["deductions"]);
                            details.TaxablePay = Convert.ToDouble(dataReader["taxable_pay"]);
                            details.IncomeTax = Convert.ToDouble(dataReader["incometax"]);
                            details.NetPay = Convert.ToDouble(dataReader["net_pay"]);
                            Console.WriteLine(details.EmployeeName + " " + details.BasicPay + " " + details.StartDate + " " + details.Gender + " " + details.PhoneNumber + " " + details.Address + " " + details.Department + " " + details.Deductions + " " + details.TaxablePay + " " + details.IncomeTax + " " + details.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
                    this.connection.Close(); //closing the connection
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateSalary(EmployeeDetails details)
        {
            try
            {
                using (this.connection)
                {
                    //Query to perform
                    string query = @"update employee_payroll set basic_pay=3000000 where name='Terissa'";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open(); //Opening the connection
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Salary Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Unsuccessful");
                    }
                    this.connection.Close(); //Closing the connection
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int UpdateSalaryusingPreparedStatement(EmployeeDetails details)
        {
            int result;
            try
            {
                using (this.connection)
                {
                    //Using stored procedure
                    SqlCommand command = new SqlCommand("dbo.UpdateEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //Adding the parameters
                    command.Parameters.AddWithValue("Id", details.EmployeeID);
                    command.Parameters.AddWithValue("Name", details.EmployeeName);
                    command.Parameters.AddWithValue("BasicPay", details.BasicPay);
                    connection.Open(); //Opening the connection
                    result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Successfully Updated using prepared statement");
                    }
                    else
                    {
                        Console.WriteLine("Not updated successfully");
                        return default;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
            finally
            {
                this.connection.Close(); //Closing the connection
            }
        }
    }
}


    
