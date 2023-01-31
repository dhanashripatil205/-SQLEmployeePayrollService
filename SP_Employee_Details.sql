use Payroll_Service
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetAllEmployeeDetails]
AS
BEGIN

select Employee_Payroll.Emp_ID, Name, Salary, StartDate, Gender, Department, Phone, Address, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
from Employee_Payroll 
left join Employee_Department on Employee_Payroll.Emp_ID = Employee_Department.ID
left join Payroll on Employee_Payroll.Emp_ID = Payroll.ID

END
GO
