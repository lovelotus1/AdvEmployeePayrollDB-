using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement
{
    class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeePayrollService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void GetAllEmployees()
        {

            try
            {
                EmployeeModel model = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"select EmployeeID,EmployeeName,PhoneNumber,Address,Department
                                    ,Gender,BasicPay,Deductions,TaxablePay,TaxPay,NetPay,StartDate,City,Country FROM employee_payroll";
                    //define the SqlCommand object
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    //check if there are record
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            model.EmployeeID = sqlDataReader.GetInt32(0);
                            model.EmployeeName = sqlDataReader.GetString(1);
                            model.PhoneNumber = sqlDataReader.GetString(2);
                            model.Address = sqlDataReader.GetString(3);
                            model.Department = sqlDataReader.GetString(4);
                            model.Gender = sqlDataReader.GetString(5);
                            model.BasicPay = Convert.ToDouble(sqlDataReader.GetDouble(6));
                            model.Deductions = Convert.ToDouble(sqlDataReader.GetDouble(7));
                            model.TaxablePay = Convert.ToDouble(sqlDataReader.GetDouble(8));
                            model.NetPay = Convert.ToDouble(sqlDataReader.GetDouble(10)); ;
                            model.StartDate = sqlDataReader.GetDateTime(11);
                            model.City = sqlDataReader.GetString(12);
                            model.Country = sqlDataReader.GetString(13);
                            //display retrieved record
                            Console.WriteLine("EmployeeId:{0}\nEmployeeName:{1}\nPhoneNumber:{2}\nAddress:{3}\nDepartment:{4}",
                                 model.EmployeeID, model.EmployeeName, model.PhoneNumber, model.Address, model.Department);

                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    //close data reader
                    sqlDataReader.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        // <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// @EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,
        /// @Deductions,@TaxablePay,@Tax,@NetPay,@StartDate,@City,@Country
        /// Adds the employee.
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.spEmployee_Payroll_AddData", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@TaxPay", model.TaxPay);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public void UpdateSalary()
        {
            try
            {

                using (connection)
                {
                    //UpdateSalary 
                    string query = "Update employee_payroll Set BasicPay='3000000.00' Where EmployeeName='Raj';";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Salary Updated");
                    }
                    else
                    {
                        Console.WriteLine("Salary not Updated");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RetreiveData()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (connection)
                {
                    //string query = "select * from employee_payroll where gender='M'";
                    string query = "select * from employee_payroll where gender='F'";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeModel.EmployeeName = reader.GetString(1);
                            employeeModel.Gender = reader.GetString(5);
                            Console.WriteLine("Employe Name: " + employeeModel.EmployeeName +  "\nGender: " + employeeModel.Gender);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void getSum()
        {

            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string querySUM = "select SUM(BasicPay) from employee_payroll";
                    string queryAVG = "select AVG(BasicPay) from employee_payroll";
                    string queryCOUNT = "select COUNT(BasicPay) from employee_payroll";
                    string queryMIN = "select MIN(BasicPay) from employee_payroll";
                    string queryMAX = "Select MAX(BasicPay) from employee_payroll ";

                    SqlCommand command = new SqlCommand(querySUM, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //double Sum = reader.GetDouble(0);
                            
                            
                            
                            
                            //Console.WriteLine("Sum of Salary " + Sum);
                            double Avg = reader.GetDouble(1);
                            Console.WriteLine("Sum of Avg " + Avg);
                            double Count = reader.GetDouble(2);
                            Console.WriteLine("Sum of Salary " + Count);
                            double Min = reader.GetDouble(3);
                            Console.WriteLine("Sum of Salary " + Min);
                            double Max = reader.GetDouble(4);
                            Console.WriteLine("Sum of Salary " + Max);

                        }

                    }
                    else
                    {
                        System.Console.WriteLine("No data found");

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
    

        
