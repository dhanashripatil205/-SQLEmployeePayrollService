using EmployeePayrollServiceSQL;

namespace Payroll_Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckFor_Connection_Establishment()
        {
            string result = Program.EstablishConnection();
            Assert.AreEqual("Connection was established.",result);
        }
    }
}
