use Payroll_Service
go
set ansi_nulls on
go
set quoted_identifier on
go

create or alter procedure [RemoveEmployeeData]
@ID int
as
set xact_abort on
set nocount on
begin 
begin try 
begin transaction
	declare @result bit = 0
	declare @Emp_ID_Check int = 0
	set @Emp_ID_Check = (select Emp_ID from Employee_Payroll where Emp_ID = @ID)
	if (@Emp_ID_Check = @ID)
		begin;
			delete from Employee_Payroll where Emp_ID = @ID	
		end
	else
		begin;
			throw 50001, 'Employee does not exit',-1;
		end
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
