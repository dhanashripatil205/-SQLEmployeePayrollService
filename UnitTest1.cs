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
    }
}
