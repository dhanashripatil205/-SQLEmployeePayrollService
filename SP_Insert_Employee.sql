use Payroll_Service
go
set ansi_nulls on
go
set quoted_identifier on
go

create procedure [InsertEmployeeData]
@Name varchar(50),
@Salary bigint,
@StartDate datetime,
@Gender varchar(1),
@Department varchar(50),
@Phone bigint,
@Address varchar(100),
@BasicPay bigint,
@Deductions bigint,
@TaxablePay bigint,
@IncomeTax bigint,
@NetPay bigint
as
set xact_abort on
set nocount on
begin 
begin try 
begin transaction
	declare @new_identity int = 0
	declare @result bit = 0
	insert into Employee_Payroll (Name,Salary,StartDate,Gender) values (@Name,@Salary,@StartDate,@Gender)
	select @new_identity = @@IDENTITY
	insert into Employee_Department(ID,Department,Phone,Address) values (@new_identity,@Department,@Phone,@Address)
	insert into Payroll(ID,BasicPay,Deductions,TaxablePay,IncomeTax,NetPay) values (@new_identity,@BasicPay,@Deductions,@TaxablePay,@IncomeTax,@NetPay)
commit transaction
set @result = 1
return @result
end try
begin catch
if(xact_state())=-1
	begin
		print
			'Transaction is Uncommitable' + 'Rolling back Transaction'
		rollback transaction
	end
if(xact_state())=1
	begin
		print
			'Transaction is Commitable'
		commit transaction
		set @result = 1
	end
return @result
end catch
end
