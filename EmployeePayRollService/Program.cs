using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Payroll Service uing ADO.Net");
            EmployeeRepository repository = new EmployeeRepository();
            repository.GetAllEmployee();
        }
    }
}