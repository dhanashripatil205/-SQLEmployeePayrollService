***** Welcome to Employee Payroll Service Problem. *****

create database payroll_service

use payroll_service

Create Table employee_payroll
(
Id int identity(1,1)primary key not null,
Name varchar(255),
Salary int,
StartDate datetime
)

insert into employee_payroll Values ('Dhanashri', 50450, '2013-03-28')
insert into employee_payroll Values ('Kriti', 30596, '2018-11-3')

select * from employee_payroll

select Salary from Employee_Payroll where Name = 'Bill'
select Name from Employee_Payroll where StartDate between '2018-01-01' and '2023-01-30'
select Name from Employee_Payroll where StartDate between '2018-01-01' and GETDATE()


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

alter table Employee_Department add constraint Same_ID_One foreign key (ID) references employee_payroll(ID)


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

create table Payroll(
ID int not null,
BasicPay bigint,
Deductions bigint,
TaxablePay bigint,
IncomeTax bigint,
NetPay bigint
)

alter table Payroll add constraint Same_ID_Two foreign key (ID) references employee_payroll(ID)


insert into Payroll Values (1,45698,130,169,363,670)
insert into Payroll Values (2,36985,500,170,132,400)
insert into Payroll Values (3,44000,120,136,456,350)
insert into Payroll Values (4,89653,360,155,950,780)
insert into Payroll Values (5,89653,570,163,431,600)
insert into Payroll Values (6,32456,110,141,161,660)


select * from Payroll

select employee_payroll.ID, Name, Salary, StartDate,Gender, Department, Phone, Address, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
from employee_payroll 
left join Employee_Department on employee_payroll.ID = Employee_Department.ID
left join Payroll on employee_payroll.ID = Payroll.ID

exec GetAllEmployeeDetails
exec UpdateDetails 1, 30450
