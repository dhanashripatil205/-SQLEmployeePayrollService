using EmployeePayrollServiceSQL;
using System.Collections.Generic;

namespace Payroll_Testing
{
     ppublic class Tests
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
    }
}
