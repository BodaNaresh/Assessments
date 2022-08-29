
create table Doctors(ID int identity(1,1) primary key,Name varchar(20),HospitalName varchar(30),Department varchar(30),Qualification varchar(20),Salary numeric);

create table patients(ID int,Name varchar(20),HospitalName varchar(30),Disease varchar(30),Address varchar(20),Postion varchar(20),Mobile bigint,ids int foreign key references Doctors(ID));

create table BedsInfo(ID int,Name varchar(20),HospitalName varchar(30),BedNo int,Allotment varchar(20),ids int foreign key references Doctors(ID));

select * from Doctors
select * from patients
select * from BedsInfo

--stored procedures
create procedure sp_Doctors
as
begin
select * from Doctors
end

exec sp_Doctors
create procedure sp_InsertDoctors(
@ID int,
@Name varchar(20),
@HospitalName varchar(30),
@Department varchar(30),
@Qualification varchar(20),
@Salary numeric
)
as
begin
insert into Doctors(ID,
Name,
HospitalName,
Department,
Qualification,
Salary)
values(
@ID,
@Name,
@HospitalName,
@Department,
@Qualification,
@Salary
)
end


---stored procedure for patients
create procedure sp_Patients
as
begin
select * from patients
end


create procedure sp_InsertPatients(
@ID int,
@Name varchar(20),
@HospitalName varchar(30),
@Disease varchar(30),
@Address varchar(20),@Position varchar(20),
@Mobile bigint
)
as
begin
insert into patients(ID,
Name,
HospitalName,
Disease,
Address,
Mobile)
values(
@ID,
@Name,
@HospitalName,
@Disease,
@Address,
@Mobile
)
end

---stored procedure for Bedsinfo
create procedure sp_bedsinfo
as
begin
select * from BedsInfo
end

create procedure sp_InsertBedsInfo(
@ID int,
@Name varchar(20),
@HospitalName varchar(30),
@BedNo varchar(30),
@Allotment varchar(20)
)
as
begin
insert into BedsInfo(ID,
Name,
HospitalName,
BedNo,
Allotment)
values(
@ID,
@Name,
@HospitalName,
@BedNo,
@Allotment
)
end


--Triggers
create table Doctors_log(LogId int identity(100,1),Did int,Operation varchar(30),Loggeddate datetime)

create table Patients_log(LogId int identity(200,1),Pid int,Operation varchar(30),Loggeddate datetime)

create table BedsInfo_log(LogId int identity(300,1),Bid int,Operation varchar(30),Loggeddate datetime)

select * from Doctors_log
select * from Patients_log
select * from BedsInfo_log

create trigger DoctorsInsertTrigger
on Doctors
for insert
as
insert into Doctors_log(Did,Operation,Loggeddate)
select ID,'Data inserted',GETDATE() from inserted

create trigger PatientsInsertTrigger
on patients
for insert
as
insert into Patients_log(Pid,Operation,Loggeddate)
select ID,'Data inserted',GETDATE() from inserted

create trigger BedsInfoInsertTrigger
on BedsInfo
for insert
as
insert into BedsInfo_log(Bid,Operation,Loggeddate)
select ID,'Data inserted',GETDATE() from inserted




