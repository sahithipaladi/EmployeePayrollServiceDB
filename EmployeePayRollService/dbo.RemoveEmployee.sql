CREATE PROCEDURE dbo.RemoveEmployee
(
@Id int
)
AS
BEGIN
	delete from employee where EmployeeId=@Id
	delete from employee_payroll where id=@Id
	delete from payroll_details where Id=@Id
END