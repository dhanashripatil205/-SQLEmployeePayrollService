using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollServiceSQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to Employee Payroll ADO.NET problem.*****");
        }
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PayRollService240;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionString);
        public static string EstablishConnection()
        {
             if (connection != null)
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return "Connection was established.";
                }
                catch (Exception ex)
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.CONNECTION_FAILED, "Connection Failed.");
                }
            }
            return "Connection was null.";
        }
        public void Connect()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
                connection.Open();
        }
        public void Dissconnect()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Open))
                connection.Close();
        }
        public Employee DatabaseReader(SqlDataReader reader, Employee emp)
        {
            emp.Emp_ID = reader.GetInt32(0);
            emp.Name = reader.GetString(1);
            emp.Salary = reader.GetInt64(2);
            emp.StartDate = reader.GetDateTime(3);
            emp.Gender = reader.GetString(4);
            emp.Department = reader.GetString(5);
            emp.Phone = reader.IsDBNull(6) ? 0 : reader.GetInt64(6);
            emp.Address = reader.IsDBNull(7) ? "" : reader.GetString(7);
            emp.BasicPay = reader.IsDBNull(8) ? 0 : reader.GetInt64(8);
            emp.Deductions = reader.IsDBNull(9) ? 0 : reader.GetInt64(9);
            emp.TaxablePay = reader.IsDBNull(10) ? 0 : reader.GetInt64(10);
            emp.IncomeTax = reader.IsDBNull(11) ? 0 : reader.GetInt64(11);
            emp.NetPay = reader.IsDBNull(12) ? 0 : reader.GetInt64(12);
            return emp;
        }
        public List<Employee> RetrieveFromDatabase()
        {
            List<Employee> employees = new();
            Employee emp = new();
            string SPName = "dbo.GetAllEmployeeDetails";
            using (connection)
            {
                SqlCommand command = new SqlCommand(SPName, connection);
                command.CommandType = CommandType.StoredProcedure;
                Connect();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatabaseReader(reader,emp);
                        employees.Add(emp);
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, " +
                            "{11}, {12}", emp.Emp_ID, emp.Name, emp.Salary, emp.StartDate, emp.Gender, 
                            emp.Department, emp.Phone, emp.Address, emp.BasicPay, emp.Deductions, 
                            emp.TaxablePay, emp.IncomeTax, emp.NetPay);
                    }
                }
                Dissconnect();
            }
            return employees;
        }
        public Employee UpdateSalary(int Emp_ID, Int64 Salary)
        {
            Employee emp = new Employee();
            string SPName = "dbo.UpdateDetails";
            using (connection)
            {
                SqlCommand command = new SqlCommand(SPName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", Emp_ID);
                command.Parameters.AddWithValue("@Salary", Salary);
                Connect();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatabaseReader(reader, emp);
                        if (emp.Emp_ID == Emp_ID)
                            return emp;
                    }
                }
                return null;
            }
        }
        public List<Employee> RetrieveFromDatabase_BetweenGivenDates(DateTime FirstDate, DateTime LastDate)
        {
            List<Employee> employees = new();
            Employee emp = new();
            string SPName = "dbo.GetAllDetails_BetweenGivenDates";
            using (connection)
            {
                SqlCommand command = new SqlCommand(SPName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstDate", FirstDate);
                command.Parameters.AddWithValue("@LastDate", LastDate);
                Connect();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatabaseReader(reader, emp);
                        employees.Add(emp);
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, " +
                            "{11}, {12}", emp.Emp_ID, emp.Name, emp.Salary, emp.StartDate, emp.Gender,
                            emp.Department, emp.Phone, emp.Address, emp.BasicPay, emp.Deductions,
                            emp.TaxablePay, emp.IncomeTax, emp.NetPay);
                    }
                }
                Dissconnect();
            }
            return employees;
        }
        public int InsertNewEmployee(Employee emp)
        {
            string SPName = "dbo.InsertEmployeeData";
            using (connection)
            {
                Connect();
                SqlCommand command = new SqlCommand(SPName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", emp.Name);
                command.Parameters.AddWithValue("@Salary", emp.Salary);
                command.Parameters.AddWithValue("@StartDate", emp.StartDate);
                command.Parameters.AddWithValue("@Gender", emp.Gender);
                command.Parameters.AddWithValue("@Department", emp.Department);
                command.Parameters.AddWithValue("@Phone", emp.Phone);
                command.Parameters.AddWithValue("@Address", emp.Address);
                command.Parameters.AddWithValue("@BasicPay", emp.BasicPay);
                command.Parameters.AddWithValue("@Deductions", emp.Deductions);
                command.Parameters.AddWithValue("@TaxablePay", emp.TaxablePay);
                command.Parameters.AddWithValue("@IncomeTax", emp.IncomeTax);
                command.Parameters.AddWithValue("@NetPay", emp.NetPay);
                var resultPara = command.Parameters.Add("@result", SqlDbType.Int);
                resultPara.Direction = ParameterDirection.ReturnValue;
                command.ExecuteNonQuery();
                Dissconnect();
                var result = resultPara.Value;
                return (int)result;
            }
        }

    }
}
