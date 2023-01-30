***** Welcome to Employee Payroll Service Problem. *****

create database payroll_service;
use payroll_service;

Create Table employee_payroll
(
Id int identity(1,1)primary key not null,
Name varchar(255),
Salary int,
StartDate datetime
)
