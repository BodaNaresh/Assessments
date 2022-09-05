
create table AdminLogin(id int primary key identity(1,1),username nvarchar(30),password nvarchar(30))
select * from AdminLogin

insert into AdminLogin values('naresh',123)

create table Franchise(fcode int primary key identity(1,1),fname nvarchar(30),location nvarchar(30),rent money,totalsales bigint,totalEmp int,Dates date)
select * from Franchise

create table FranchiseLogin(fid int primary key identity(1,1),funiqueID nvarchar(30),password nvarchar(30))
select * from FranchiseLogin

insert into FranchiseLogin values('n@123',1234)

create table Employee_franchise(id int primary key identity(1,1),Name nvarchar(30),SalaryDistribution money,Mobile numeric,Saletype nvarchar(30),fcode int foreign key references Franchise(fcode))
select * from Employee_franchise


create procedure sp_Employee
as
begin
select e.id,e.Name,e.Mobile,f.location,e.Saletype,f.totalsales from Employee_franchise as e inner join  Franchise as f on e.fcode=f.fcode 
end

exec sp_Employee 


create procedure sp_franchise
as
begin
select e.fcode,f.fname,f.Dates,f.totalsales,f.location from Franchise as f inner join Employee_franchise as e on e.fcode=f.fcode
end
exec sp_franchise


create procedure sp_salesrecordSalarydistribute
as
begin
select e.id,e.name,e.SalaryDistribution,f.dates,e.saletype,f.totalsales from Franchise as f inner join Employee_franchise as e on e.fcode=f.fcode 
end

