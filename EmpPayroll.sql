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

select Salary from Employee_Payroll where Name = 'Bill'
select Name from Employee_Payroll where StartDate between '2018-01-01' and '2023-01-30'


alter table employee_payroll
add Gender char(1)

update employee_payroll
set Gender = 'M'

update employee_payroll
set Gender = 'F'
where name in('Dhanashri','Kriti')

select SUM(Salary) FROM employee_payroll
where Gender = 'F' GROUP BY Gender;

select AVG(Salary) FROM employee_payroll
where Gender = 'F' GROUP BY Gender;

select MIN(Salary) FROM employee_payroll
where Gender = 'F' GROUP BY Gender;

select MAX(Salary) FROM employee_payroll
where Gender = 'F' GROUP BY Gender;

select COUNT(Salary) FROM employee_payroll
where Gender = 'F' GROUP BY Gender;

create table Employee_Department(
ID int not null,
Department varchar(150) not null,
Phone int, 
Address varchar(120),
) 

select * from Employee_Department

insert into Employee_Department Values (1,'IT',9406986233,'Mumbai')
insert into Employee_Department Values (2,'Sales',9862539866, 'Goa')
insert into Employee_Department Values (3,'AWS',9456986236,'Tamilnadu')
insert into Employee_Department Values (4,'Cloud',9865325689,'Kerla')
insert into Employee_Department Values (5,'Asset',9463289633,'Bengol')
insert into Employee_Department Values (6,'Hardware',9410369855,'US')

select employee_payroll.ID, Name, Salary, StartDate, Gender, Department, Phone, Address
from employee_payroll
left join Employee_Department on employee_payroll.ID = Employee_Department.ID
