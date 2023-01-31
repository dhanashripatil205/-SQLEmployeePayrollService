use Payroll_Service
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [UpdateDetails]
@ID int,
@Salary bigint
AS
SET NOCOUNT ON
BEGIN
begin try
begin transaction
	declare @RowCount integer
	update Employee_Payroll Set Salary = @Salary where Emp_ID = @ID
	exec GetAllEmployeeDetails
	select @RowCount = @@ROWCOUNT
commit transaction
end try
begin catch
select ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage
if(XACT_STATE())=-1
	begin
		print
			'Transaction is Uncommitable' + 'Rolling back Transaction'
		rollback transaction
	end
else if(XACT_STATE())=1
	begin
		print
			'Transaction is Commitable'
		commit transaction
	end
else
	begin
		print
			'Transaction Failed'
		rollback transaction
	end
end catch
return @RowCount
END
GO
