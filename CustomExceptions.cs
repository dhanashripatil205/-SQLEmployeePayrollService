using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollServiceSQL
{
    public class CustomExceptions : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            CONNECTION_FAILED
        }
        public CustomExceptions(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
