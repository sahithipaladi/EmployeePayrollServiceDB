CREATE PROCEDURE dbo.InsertIntoTable
(
    @Id int,
	@Name varchar(200),
	@Basic_Pay float,
	@StartDate Date,
	@Gender char(1),
	@PhoneNumber varchar(20),
	@Address varchar(150),
	@Department varchar(150),
	@Taxable_Pay float,
	@Deductions float,
	@Net_Pay float,
	@IncomeTax float
	)
AS
BEGIN
	Insert into employee_payroll(id,name,Basic_pay,StartDate,Gender,Phonenumber,Address,Department,Taxable_Pay,Deductions,Net_Pay,Incometax) values(@Id,@Name,@Basic_Pay,GETDATE(),@Gender,@PhoneNumber,@Address,@Department,@Taxable_Pay,@Deductions,@Net_Pay,@Incometax)
	Insert into employee(EmployeeId,Name,Gender,PhoneNumber,Address) values(@Id,@Name,@Gender,@PhoneNumber,@Address)
	Insert into payroll_details(Id,StartDate,Basic_pay,Deductions,Taxable_pay,Net_pay,Incometax) values(@Id,GETDATE(),@Basic_Pay,@Deductions,@Taxable_Pay,@Net_Pay,@Incometax)
END