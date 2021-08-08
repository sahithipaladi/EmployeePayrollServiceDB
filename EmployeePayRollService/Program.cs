using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Payroll Service using ADO.Net");
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeDetails details = new EmployeeDetails();

            details.EmployeeID = 10;
            details.EmployeeName = "Sahithi";
            details.BasicPay = 394856;
            details.Gender = "F";
            details.PhoneNumber = "9999886655";
            details.Address = "Kerala";
            details.Department = "HR";
            details.TaxablePay = 1000;
            details.Deductions = 100;
            details.Net_Pay = 20000;
            details.IncomeTax = 200;
            bool result = repository.AddEmployee(details);
            if (result)
                Console.WriteLine("Successfully removed");
            else
                Console.WriteLine("Not removed");
        }
    }
}

