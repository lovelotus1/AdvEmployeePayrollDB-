using System;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to EmployeePayroll");
            EmployeeRepo employeeRepository = new EmployeeRepo();
            employeeRepository.GetAllEmployees();
            
        }
    }
}