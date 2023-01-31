using EmployeePayrollServiceSQL;
using System.Collections.Generic;

namespace Payroll_Testing
{
     public class Tests
    {
        Program program;
        Employee employee;
        [SetUp]
        public void Setup()
        {
            program = new Program();
            employee = new Employee();
        }

        [Test]
        public void CheckFor_Connection_Establishment()
        {
            string result = program.EstablishConnection();
            Assert.AreEqual("Connection was established.",result);
        }
        [Test]
        public void Retrieve_Details_FromDatabase()
        {
            List<Employee> employees = new List<Employee>();
            employees = program.RetrieveFromDatabase();
            Assert.IsNotNull(employees);
        }
        [Test]
        public void Update_Salary_ForTushar()
        {
            int Emp_ID = 1;
            Int64 newSalary = 300000;
            employee = program.UpdateSalary(Emp_ID, newSalary);
            Assert.AreEqual(newSalary, employee.Salary);
        }
        [Test]
        public void Retrieve_Details_FromDatabase_BetweenGivenDates()
        {
            List<Employee> employees = new List<Employee>();
            DateTime FirstDate = DateTime.Parse("2017-01-01");
            DateTime LastDate = DateTime.Parse("2018-12-31");
            employees = program.RetrieveFromDatabase_BetweenGivenDates(FirstDate, LastDate);
            Assert.AreEqual(3, employees.Count);
        }
        [Test]
        public void Insert_New_Employee_Details()
        {
            employee = new Employee();
            employee.Name = "TestEmployee";
            employee.Salary = 100000;
            employee.StartDate = DateTime.Now;
            employee.Gender = "M";
            employee.Department = "Marketing";
            employee.Phone = 9638527410;
            employee.Address = "India";
            employee.BasicPay = 5000;
            employee.Deductions = 500;
            employee.TaxablePay = 400;
            employee.IncomeTax = 250;
            employee.NetPay = 600;
            int result = program.InsertNewEmployee(employee);
            Assert.AreEqual(1, result);
        }
        [Test]
        public void Remove_Employee_Details_Return_Expected()
        {
            int ID = 11;
            int result = program.RemoveEmployee(ID);
            Assert.AreEqual(1, result);
        }
    }
}
