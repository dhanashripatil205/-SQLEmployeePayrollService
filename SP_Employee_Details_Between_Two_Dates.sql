use Payroll_Service
go
set ansi_nulls on
go
set quoted_identifier on
go

create procedure [GetAllDetails_BetweenGivenDates]
@FirstDate datetime,
@LastDate datetime
as
begin
	set nocount on
	select Employee_Payroll.Emp_ID, Name, Salary, StartDate, Gender, Department, Phone, Address, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
	from Employee_Payroll 
	left join Employee_Department on Employee_Payroll.Emp_ID = Employee_Department.ID
	left join Payroll on Employee_Payroll.Emp_ID = Payroll.ID
	where StartDate between @FirstDate and @LastDate
end
go
Footer
© 2023 GitHub, Inc.
Footer navigation
Terms
Privacy
