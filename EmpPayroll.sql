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

insert into employee_payroll Values ('Dhanashri', 50450, '2023-03-28')
insert into employee_payroll Values ('Kriya', 30596, '2022-11-26')

select * from employee_payroll
