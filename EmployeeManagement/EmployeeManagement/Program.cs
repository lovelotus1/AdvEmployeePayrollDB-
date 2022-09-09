﻿using System;

namespace EmployeeManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to EmployeePayroll");
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();
            //repo.GetAllEmployees();
            employee.EmployeeName = "Sam";
            employee.PhoneNumber = "9765999999";
            employee.Address = "Delhi";
            employee.Department = "HR";
            employee.Gender = "M";
            employee.BasicPay = 420000;
            employee.Deductions = 1300.50;
            employee.TaxablePay = 5000.00;
            employee.NetPay = 36660;
            employee.StartDate = Convert.ToDateTime("2020-11-03");
            employee.City = "Ranchi";
            employee.Country = "India";
            //repo.AddEmployee(employee);
            repo.GetAllEmployees();

        }
    }
}