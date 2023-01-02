-- creating the DataBase named payrollManagementDB
create database payrollManagementDB

-- select DataBase 
use payrollManagementDB

-- create Table named [DepartmentsTable]
CREATE TABLE [DepartmentsTable]
(
	[departmentID] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [departmentName] VARCHAR(50) NOT NULL
)
CREATE TABLE [DesignationTable]
(
	[designationID] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [designationName] VARCHAR(50) NOT NULL, 
	[PerDay] INT NOT NULL,
    [BonusPerHour] INT NOT NULL
)

CREATE TABLE AttendanceTable(
	employeeID INT NOT NULL,
	[Date] Date NOT NULL,
	[Status] VARCHAR(50) NOT NULL,
	Leave VARCHAR(100)NULL,
	PRIMARY KEY(employeeID,[DATE]),
	FOREIGN KEY (employeeID) REFERENCES [EmployeesTable]([employeeID])
)
select * from EmployeesTable
insert into AttendanceTable (employeeID,[Date],[Status]) values (1,'2022-11-13','Present')
select * from AttendanceTable
DELETE FROM AttendanceTable WHERE employeeID=1 and Status = 'Leave' and Date = '2022-11-19';

select * from BonusTable
CREATE TABLE BonusTable(
	employeeID INT NOT NULL,
	[Date] Date NOT NULL,
	[Hours] INT NOT NULL,
	Details VARCHAR(500) NULL,
	PRIMARY KEY (employeeID, [Date]),
	FOREIGN KEY (employeeID) REFERENCES [EmployeesTable]([employeeID])
)

CREATE TABLE ToDoTable(
	employeeID INT NOT NULL,
	[Date] DATE NOT NULL,
	Details VARCHAR(500) NOT NULL,
	[Status] VarChar (50),
	FOREIGN KEY (employeeID) REFERENCES [EmployeesTable]([employeeID])
)

insert into ToDoTable values (4,'2022-12-13' ,'Learn Developement','Pending')
select * from ToDoTable where employeeID =1
select * from employeesTable
update EmployeesTable set employeeName = '',employeeDOB = '',employeeNIC = '',employeeContact='',gender='',houseNo='',street='',town='',city='' where employeeID = 1



CREATE TABLE PayrollTable(
	employeeID INT NOT NULL,
	Details VARCHAR(500) NULL,
	[Year] VARCHAR(100),
	[Month] VARCHAR(100),
	[Date] DATE NOT NULL, --DATE - format YYYY-MM-DD
	Deduction int NULL,
	Bonus int NULL,
	TotalSalary int NULL,
	PRIMARY KEY (employeeID, [Month],[Year]),
	FOREIGN KEY (employeeID) REFERENCES [EmployeesTable]([employeeID])
)
select * from PayrollTable
select * from departmentstable
select * from DesignationTable
CREATE TABLE [EmployeesTable]
(
	[employeeID] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [employeeName] VARCHAR(50) NOT NULL,
	[employeeEmail] VARCHAR(50) NOT NULL,
    [employeeNIC] VARCHAR(50) NOT NULL, 
    [employeeDOB] DATE NULL, --DATE - format YYYY-MM-DD 

    [employeeDepartment] INT NULL, 
    [employeeDesignation] INT NOT NULL, 
    [joiningDate] DATE NOT NULL,
	

    [employeeContact] VARCHAR(50) NULL, 
    [gender] VARCHAR(10) NULL,

	[houseNo] VARCHAR(50) NULL, 
    [street] VARCHAR(50) NULL, 
    [town] VARCHAR(100) NULL, 
    [city] VARCHAR(150) NOT NULL,

    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(50) NULL, 

	FOREIGN KEY ([employeeDepartment]) REFERENCES [DepartmentsTable]([departmentID]),
	FOREIGN KEY ([employeeDesignation]) REFERENCES [DesignationTable]([designationID])
)

-- make employeeEmail and employeeNIC unique
ALTER TABLE [EmployeesTable] ADD CONSTRAINT UC_EmployeeEmail UNIQUE (employeeEmail)
ALTER TABLE [EmployeesTable] ADD CONSTRAINT UC_EmployeeNIC UNIQUE (employeeNIC)

-- Applying indexes on the employeeNIC and employeeEmail
CREATE INDEX IX_EmployeeNIC ON [EmployeesTable] (employeeNIC)


alter table employeestable 
drop column isadmin
select  * from [EmployeesTable]
insert into [EmployeesTable] (employeeName,employeeEmail,employeeNIC,employeeDOB,employeeDepartment,
employeeDesignation,joiningDate,employeeContact,gender,houseNo,street,town,city) 
values (
	'Ali Raza',
	'aliraza@gmail.com',
	'33105-6823349-9',
	'2002-01-13',
	7,
	1,
	'2020-01-13',
	'0302-5414924',
	'Male',
	'48',
	'Mian Ameer O Din Park',
	'Tajpura',
	'Lahore'
	)


--Inserting values in the table
insert into [DepartmentsTable] values (
	'Research & Developement'
)
--Inserting values in the table
insert into [DesignationTable] values (
	'Team Member',
	100,
	800
)
select * from [DepartmentsTable]
select * from [DesignationTable]
select * from employeestable


-- Getting employeeid,emoloyeename,employeenic, employeecontact, employeeemail, departmentName, designationName, city
select 
	employeeID,
	employeeName,
	employeeNIC,
	employeeContact,
	employeeEmail,
	departmentName,
	designationName,
	city
from
	[EmployeesTable] as e
inner join
	[DepartmentsTable] as d
on
	e.employeeDepartment = d.departmentID
inner join
	[DesignationTable] as s	
on
	e.employeeDesignation = s.designationID
	

select * from departmentsTable
select * from DesignationTable
select * from PayrollTable
select * from EmployeesTable
UPDATE EmployeesTable
SET employeeEmail = 'arwa@gmail.com',city = 'RYK'
WHERE employeeID = 6;
select username,password,employeeID,employeeName,employeeNIC,employeeContact,employeeEmail,departmentName,designationName,city from [EmployeesTable] as e inner join [DepartmentsTable] as d on e.employeeDepartment = d.departmentID inner join [DesignationTable] as s on e.employeeDesignation = s.designationID

select * from AttendanceTable


-- calculate the present, absent, leaves, rejected Leaves, Accepted Leaves of the employee OF current month of All Employees
select employeeId
, (select count(*) from AttendanceTable where employeeId = a.employeeId and Status = 'Present' and Date like '2022-11%') as Present
, (select count(*) from AttendanceTable where employeeId = a.employeeId and Status = 'Absent' and Date like '2022-11%') as Absent
, (select count(*) from AttendanceTable where employeeId = a.employeeId and Status = 'Leave' and Date like '2022-11%') as Leaves
, (select count(*) from AttendanceTable where employeeId = a.employeeId and Status = 'Leave' and Leave = 'Rejected' and Date like '2022-11%') as RejectedLeaves
, (select count(*) from AttendanceTable where employeeId = a.employeeId and Status = 'Leave' and Leave = 'Accepted' and Date like '2022-11%') as AcceptedLeaves
from AttendanceTable a
group by employeeId




-- calculate the no of present employees, no of absent employees, no of leaves, no of rejected leaves, no of accepted leaves of the current date
select 
	(select count(*) from AttendanceTable where Status = 'Present' and Date = '2022-11-04') as Present
,	(select count(*) from AttendanceTable where Status = 'Leave' and Date = '2022-11-04') as Leaves
,	(select count(*) from AttendanceTable where Status = 'Leave' and Leave = 'Rejected' and Date = '2022-11-04') as RejectedLeaves
,	(select count(*) from AttendanceTable where Status = 'Leave' and Leave = 'Accepted' and Date = '2022-11-04') as AcceptedLeaves


select * from BonusTable

INSERT into BonusTable values(1,'2022-11-04',3,'This is Sample Bonus')



select employeeId
, (select sum(Hours) from BonusTable where employeeId = b.employeeId and Date like '2022-11%') as TotalBonusHours
from BonusTable b
group by employeeId


-- find employeeId, employeeName, BonusDate, BonusHours, caluculate the totalBonus by multiplying the BonusHours with the BonusRate( which is in the DesignationTable) in descending order of totalBonus

select 
	e.employeeId
,	e.employeeName
,	b.Date
,	b.Hours
,	(select BonusPerHour from DesignationTable where designationID = e.employeeDesignation) * b.Hours as TotalBonus
from BonusTable b
inner join EmployeesTable e
on b.employeeId = e.employeeID
order by TotalBonus desc


select e.employeeId,e.employeeName,b.Date,b.Hours,(select BonusPerHour from DesignationTable where designationID = e.employeeDesignation) * b.Hours as TotalBonus from BonusTable b inner join EmployeesTable e on b.employeeId = e.employeeID order by Date desc


-- Find employeeID and employeeName who are present and absent and their leaveStatus if they are on leave

select 
	e.employeeId
,	e.employeeName
,	a.Status
,   a.Leave
from AttendanceTable a
inner join EmployeesTable e
on a.employeeId = e.employeeID
where a.Date = '2022-11-04'
order by a.Status desc
select e.employeeId,e.employeeName,a.Status,a.Leave from AttendanceTable a inner join EmployeesTable e on a.employeeId = e.employeeID where a.Date = '2022-11-03' order by a.Status desc

insert into AttendanceTable (employeeID,[Date],[Status]) values (1,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status]) values (2,'2022-12-11','Absent')
insert into AttendanceTable (employeeID,[Date],[Status]) values (3,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status]) values (4,'2022-12-11','Absent')
insert into AttendanceTable (employeeID,[Date],[Status]) values (5,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status]) values (6,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status],Leave) values (7,'2022-12-11','Leave','Accepted')
insert into AttendanceTable (employeeID,[Date],[Status]) values (8,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status]) values (9,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status]) values (10,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status]) values (11,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status],Leave) values (12,'2022-12-11','Present','Rejected')
insert into AttendanceTable (employeeID,[Date],[Status]) values (13,'2022-12-11','Present')
insert into AttendanceTable (employeeID,[Date],[Status]) values (14,'2022-12-11','Present')


-- create procedure to find employeeName,EmployeeCINIC, employeeContact,departmantName,designationName,totalPresents,totalAbsents and rejectedLeaves ,acceptedLeaves, PerDay,BonusPerHour from employeeID and monthYear
CREATE PROCEDURE SPEmployeeDetails
@employeeID int,
@monthYear varchar(50)
AS
BEGIN
	DECLARE @employeeName varchar(50)
	DECLARE @employeeCINIC varchar(50)
	DECLARE @employeeContact varchar(50)
	DECLARE @departmentName varchar(50)
	DECLARE @designationName varchar(50)
	DECLARE @totalPresents int
	DECLARE @totalAbsents int
	DECLARE @rejectedLeaves int
	DECLARE @acceptedLeaves int
	DECLARE @PerDay int
	DECLARE @BonusPerHour int
	SELECT @employeeName = (select employeeName from EmployeesTable where employeeID = @employeeID)
	SELECT @employeeCINIC = (select employeeNIC from EmployeesTable where employeeID = @employeeID)
	SELECT @employeeContact = (select employeeContact from EmployeesTable where employeeID = @employeeID)
	SELECT @departmentName = (select departmentName from DepartmentsTable where departmentID = (select employeeDepartment from EmployeesTable where employeeID = @employeeID))
	SELECT @designationName = (select designationName from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	SELECT @totalPresents = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Present' and Date like @MonthYear) 
	SELECT @totalAbsents = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Absent' and Date like @MonthYear) 
	SELECT @rejectedLeaves = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Leave' and Leave = 'Rejected' and Date like @MonthYear)
	SELECT @acceptedLeaves = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Leave' and Leave = 'Accepted' and Date like @MonthYear)
	SELECT @PerDay = (select PerDay from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	SELECT @BonusPerHour = (select BonusPerHour from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	SELECT @employeeName as EmployeeName, @employeeCINIC as EmployeeCINIC, @employeeContact as EmployeeContact, @departmentName as DepartmentName, @designationName as DesignationName, @totalPresents as TotalPresents, @totalAbsents as TotalAbsents, @rejectedLeaves as RejectedLeaves, @acceptedLeaves as AcceptedLeaves, @PerDay as PerDay, @BonusPerHour as BonusPerHour
END

DECLARE	@return_value int EXEC	@return_value = SPEmployeeDetails @employeeID = 14, @monthYear ='2022-12%'


--Calculate Total Salary Bonus
CREATE PROCEDURE SPCalculateTotalSalaryBonus
@employeeID int,
@monthYear varchar(50)
AS
BEGIN
	DECLARE @totalSalary int
	DECLARE @totalPresent int
	DECLARE @totalAbsent int
	DECLARE @totalBonus int
	DECLARE @totalLeaves int
	DECLARE @totalLeavesAccepted int
	DECLARE @totalLeavesRejected int
	DECLARE @totalDeduction int
	DECLARE @totalDeductionDays int
	DECLARE @totalSalaryAfterDeduction int
	DECLARE @totalSalaryAfterBonus int
	DECLARE @bonusHours int
	SELECT @bonusHours = (select sum(Hours) from BonusTable where employeeId = @employeeID and Date like @MonthYear)
	SELECT @totalPresent = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Present' and Date like @MonthYear) 
	SELECT @totalAbsent = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Absent' and Date like @MonthYear) 
	SELECT @totalSalary = 30* (select PerDay from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	SELECT @totalBonus =  @bonusHours* (select BonusPerHour from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	
	IF @totalBonus is NULL
	BEGIN
	SELECT @totalBonus = 0
	END
	
	SELECT @totalLeaves = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Leave' and Date like @MonthYear)
	SELECT @totalLeavesAccepted = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Leave' and Leave = 'Accepted' and Date like @MonthYear)
	SELECT @totalLeavesRejected = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Leave' and Leave = 'Rejected' and Date like @MonthYear)


	IF @totalAbsent > 2 AND @totalLeavesRejected > 1
	BEGIN
		SELECT @totalDeductionDays = @totalAbsent + @totalLeaves - 2
	END
	ELSE
	BEGIN
		SELECT @totalDeductionDays = 0
	END

	SELECT @totalDeduction = @totalDeductionDays * (select PerDay from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	
	SELECT @totalSalaryAfterDeduction = @totalSalary - @totalDeduction
	SELECT @totalSalaryAfterBonus = @totalSalaryAfterDeduction + @totalBonus
	SELECT @totalSalary as TotalSalary, @totalBonus as TotalBonus,  @totalDeduction as TotalDeduction, @totalSalaryAfterDeduction as TotalSalaryAfterDeduction, @totalSalaryAfterBonus as TotalSalaryAfterBonus
END

DECLARE	@return_value int EXEC	@return_value = SPCalculateTotalSalaryBonus @employeeID = 14, @monthYear ='2022-12%'



-- create procedure to find employeeName,EmployeeCINIC, employeeContact,departmantName,designationName,PerDay, BonusPerHour, totalPresents,totalAbsents and rejectedLeaves ,acceptedLeaves, totalSalary,totalBonus,totalDeduction,totalSalaryAfterDeduction,totalSalaryAfterBonus from employeeID and monthYear
CREATE PROCEDURE SPEmployeeDetailsWithSalary
@employeeID int,
@monthYear varchar(50)
AS
BEGIN
	DECLARE @employeeName varchar(50)
	DECLARE @employeeContact varchar(50)
	DECLARE @departmentName varchar(50)
	DECLARE @designationName varchar(50)
	DECLARE @totalPresents int
	DECLARE @totalAbsents int
	DECLARE @rejectedLeaves int
	DECLARE @totalDeductionDays int
	DECLARE @acceptedLeaves int
	DECLARE @PerDay int
	DECLARE @BonusPerHour int
	DECLARE @totalSalary int
	DECLARE @totalBonus int
	DECLARE @totalDeduction int
	DECLARE @totalSalaryAfterDeduction int
	DECLARE @totalSalaryAfterBonus int
	SELECT @employeeName = (select employeeName from EmployeesTable where employeeID = @employeeID)
	SELECT @employeeContact = (select employeeContact from EmployeesTable where employeeID = @employeeID)
	SELECT @departmentName = (select departmentName from DepartmentsTable where departmentID = (select employeeDepartment from EmployeesTable where employeeID = @employeeID))
	SELECT @designationName = (select designationName from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	SELECT @totalPresents = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Present' and Date like @MonthYear) 
	SELECT @totalAbsents = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Absent' and Date like @MonthYear) 
	SELECT @rejectedLeaves = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Leave' and Leave = 'Rejected' and Date like @MonthYear)
	SELECT @acceptedLeaves = (select count(*) from AttendanceTable where employeeId = @employeeID and Status = 'Leave' and Leave = 'Accepted' and Date like @MonthYear)
	SELECT @PerDay = (select PerDay from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	SELECT @BonusPerHour = (select BonusPerHour from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	SELECT @totalSalary = 30* (select PerDay from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	DECLARE @bonusHours int
	SELECT @bonusHours = (select sum(Hours) from BonusTable where employeeId = @employeeID and Date like @MonthYear)
	SELECT @totalBonus =  @bonusHours* (select BonusPerHour from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	Declare @totalLeaves int
	SELECT @totalLeaves = @rejectedLeaves+@acceptedLeaves

	IF @totalBonus is NULL
	BEGIN
	SELECT @totalBonus = 0
	END
	IF @totalAbsents > 2 AND @rejectedLeaves > 1
	BEGIN
		SELECT @totalDeductionDays = @totalAbsents + @totalLeaves - 2
	END
	ELSE
	BEGIN
		SELECT @totalDeductionDays = 0
	END

	SELECT @totalDeduction = @totalDeductionDays * (select PerDay from DesignationTable where designationID = (select employeeDesignation from EmployeesTable where employeeID = @employeeID))
	
	SELECT @totalSalaryAfterDeduction = @totalSalary - @totalDeduction
	SELECT @totalSalaryAfterBonus = @totalSalaryAfterDeduction + @totalBonus
	SELECT @employeeName as EmployeeName, @employeeContact as EmployeeContact, @departmentName as DepartmentName, @designationName as DesignationName, @totalPresents as TotalPresents, @totalAbsents as TotalAbsents, @rejectedLeaves as RejectedLeaves, @acceptedLeaves as AcceptedLeaves, @PerDay as PerDay, @BonusPerHour as BonusPerHour, @totalSalary as TotalSalary, @totalBonus as TotalBonus,  @totalDeduction as TotalDeduction, @totalSalaryAfterDeduction as TotalSalaryAfterDeduction, @totalSalaryAfterBonus as TotalSalaryAfterBonus
END

DECLARE	@return_value int EXEC	@return_value = SPEmployeeDetailsWithSalary @employeeID = 14, @monthYear ='2022-12%'



select * from attendanceTable

insert into AttendanceTable (employeeID,[Date],[Status]) values (1,'2022-12-11','Present')

-- Procedure to mark attendance
CREATE PROCEDURE SPMarkAttendance
@employeeID int,
@date varchar(50),
@status varchar(50)
AS
BEGIN
	if @status = 'LeaveAccepted'
	BEGIN
		insert into AttendanceTable (employeeID,[Date],[Status],Leave) values (@employeeID,@date ,'Leave','Accepted')
	END
	ELSE IF @status = 'LeaveRejected'
	BEGIN
		insert into AttendanceTable (employeeID,[Date],[Status],Leave) values (@employeeID,@date ,'Leave','Rejected')
	END
	ELSE
	BEGIN
		insert into AttendanceTable (employeeID,[Date],[Status]) values (@employeeID,@date ,@status)
	END

END

EXEC SPMarkAttendance @employeeID = 7, @status ='Present',@date = '2021-10-10'

-- Create table for previous salarydetails where employeeID and designationID is foreign key
CREATE TABLE PreviousSalaryTable
(
	designationID int  null,
	changedBy int  null,
	[PerDay] INT NOT NULL,
    [BonusPerHour] INT NOT NULL,
	wasValidTill date,
	FOREIGN KEY (designationID) REFERENCES DesignationTable(designationID),
	FOREIGN KEY (changedBy) REFERENCES EmployeesTable([employeeID])
)


-- Create a Procedure to show all the employees of a particular department by departmentName
CREATE PROCEDURE SPEmployeesOfDepartment
@departmentName varchar(50)
AS
BEGIN
	SELECT employeeID,employeeName,employeeContact,employeeEmail,designationName
	FROM EmployeesTable
	INNER JOIN DepartmentsTable ON EmployeesTable.employeeDepartment = DepartmentsTable.departmentID
	INNER JOIN DesignationTable ON EmployeesTable.employeeDesignation = DesignationTable.designationID
	WHERE departmentName = @departmentName
END

EXEC SPEmployeesOfDepartment @departmentName = 'Marketing'

-- Create a VIEW to show Managing directors of all the departments
CREATE VIEW VManagingDirectors
AS
SELECT employeeID,employeeName,employeeContact,employeeEmail,departmentName
FROM EmployeesTable
INNER JOIN DepartmentsTable ON EmployeesTable.employeeDepartment = DepartmentsTable.departmentID
INNER JOIN DesignationTable ON EmployeesTable.employeeDesignation = DesignationTable.designationID
WHERE designationName = 'Managing Director'

select * from VManagingDirectors




-- how to Insert the designationId, perDay, BonusPerHour from the DesignationTable and changedBy and wasValidTill new entries in the PreviousSalaryTable while change the values in designationTable using trigger
CREATE PROCEDURE SPChangeSalary
@designationID int,
@changedBy int,
@PerDay int,
@BonusPerHour int,
@wasValidTill date
AS
BEGIN
DECLARE @FindBonusPerHour INT
DECLARE @FindPerDay INT
SELECT @FindBonusPerHour = BonusPerHour FROM DesignationTable WHERE designationID = @designationID
SELECT @FindPerDay = PerDay FROM DesignationTable WHERE designationID = @designationID
	INSERT INTO PreviousSalaryTable (designationID,changedBy,PerDay,BonusPerHour,wasValidTill) VALUES (@designationID,@changedBy,@FindPerDay,@FindBonusPerHour,@wasValidTill)
	UPDATE DesignationTable SET PerDay = @PerDay, BonusPerHour = @BonusPerHour WHERE designationID = @designationID
END
select * from DesignationTable
select * from PreviousSalaryTable
-- call the procedure
EXEC SPChangeSalary @designationID = 7, @changedBy = 1, @PerDay = 7100, @BonusPerHour = 910, @wasValidTill = '2021-12-31'


--call userdefined function in select query
SELECT employeeID,employeeName,employeeContact,employeeEmail,FDesignationName(employeeDesignation) as DesignationName
FROM EmployeesTable
where employeeID = 1



delete from attendanceTable where employeeid = 1 and date = '2022-12-17'

select * from AttendanceTable

select * from PayrollTable

select * from BonusTable
insert into BonusTable  values(1,'2022-12-17',1,1)
delete from PayrollTable

select * from PreviousSalaryTable

-- write a function that will take department name and will return departmentid
CREATE FUNCTION FDepartmentID(@departmentName varchar(50))
RETURNS int
AS
BEGIN
	DECLARE @departmentID int
	SELECT @departmentID = departmentID FROM DepartmentsTable WHERE departmentName = @departmentName
	RETURN @departmentID
END


SELECT payrollManagementDB.dbo.[FDepartmentID]('Marketing')

-- write a function that will take designation name and will return designationid
CREATE FUNCTION FDesignationID(@designationName varchar(50))
RETURNS int
AS
BEGIN
	DECLARE @designationID int
	SELECT @designationID = designationID FROM DesignationTable WHERE designationName = @designationName
	RETURN @designationID
END


SELECT payrollManagementDB.dbo.[FDesignationID]('Managing Director')

-- new table for updating the department and designation of an employee
CREATE TABLE PreviousDetails
(
	employeeID int not null,
	PrevDepartID int not null,
	NewDepartID int  null,
	PrevDesigID int not null,
	NewDesigID int  null,
	updatedBy int  null,
	updatedOn date not null ,
	PRIMARY KEY (employeeID,PrevDepartID,PrevDesigID,updatedon),
	FOREIGN KEY (employeeID) REFERENCES EmployeesTable([employeeID]),
	FOREIGN KEY (PrevDepartID) REFERENCES DepartmentsTable([departmentID]),
	FOREIGN KEY (PrevDesigID) REFERENCES DesignationTable([designationID]),
	FOREIGN KEY (NewDepartID) REFERENCES DepartmentsTable([departmentID]),
	FOREIGN KEY (NewDesigID) REFERENCES DesignationTable([designationID]),
	FOREIGN KEY (updatedBy) REFERENCES EmployeesTable([employeeID])
)

-- create a procedure to update the department and designation of an employee and insert the previous details in the PreviousDetails table
CREATE PROCEDURE SPUpdateEmployeeDetails
@employeeID int,
@PrevDepartID int,
@PrevDesigID int,
@NewDepartID int,
@NewDesigID int,
@updatedBy int,
@updatedOn date
AS
BEGIN
	INSERT INTO PreviousDetails (employeeID,PrevDepartID,PrevDesigID,NewDepartID,NewDesigID,updatedBy,updatedOn) VALUES (@employeeID,@PrevDepartID,@PrevDesigID,@NewDepartID,@NewDesigID,@updatedBy,@updatedOn)
	UPDATE EmployeesTable SET employeeDepartment = @NewDepartID, employeeDesignation = @NewDesigID WHERE employeeID = @employeeID
END

-- call the procedure
EXEC SPUpdateEmployeeDetails @employeeID = 1, @PrevDepartID = 1, @PrevDesigID = 1, @NewDepartID = 2, @NewDesigID = 2, @updatedBy = 1, @updatedOn = '2022-12-17'

select * from EmployeesTable
select * from PreviousDetails

-- Function to return the employee name by employeeID
CREATE FUNCTION FEmployeeName(@employeeID int)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @employeeName varchar(50)
	SELECT @employeeName = employeeName FROM EmployeesTable WHERE employeeID = @employeeID
	RETURN @employeeName
END



-- create a function to return the department name by departmentID
CREATE FUNCTION FDepartmentName(@departmentID int)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @departmentName varchar(50)
	SELECT @departmentName = departmentName FROM DepartmentsTable WHERE departmentID = @departmentID
	RETURN @departmentName
END
-- create a function to return the designation name by designationID
CREATE FUNCTION FDesignationName(@designationID int)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @designationName varchar(50)
	SELECT @designationName = designationName FROM DesignationTable WHERE designationID = @designationID
	RETURN @designationName
END


-- Name of employee previousDesignation name , newDesignation name, previousDepartment name, newDepartment name updatedBy and updatedOn
SELECT employeeName, payrollManagementDB.dbo.FDesignationName(PrevDesigID) as PreviousDesignation, payrollManagementDB.dbo.FDesignationName(NewDesigID) as NewDesignation, payrollManagementDB.dbo.FDepartmentName(PrevDepartID) as PreviousDepartment, payrollManagementDB.dbo.FDepartmentName(NewDepartID) as NewDepartment, payrollManagementDB.dbo.FEmployeeName(updatedBy) as UpdatedBy, updatedOn
FROM EmployeesTable
INNER JOIN PreviousDetails ON EmployeesTable.employeeID = PreviousDetails.employeeID

-- procedure to get previous and new department name if department is changed and previous and new designation name if designation is changed from the PreviousDetails table of all employees
CREATE PROCEDURE SPGetPreviousAndNewDetails
AS
BEGIN
	SELECT employeeName, payrollManagementDB.dbo.FDesignationName(PrevDesigID) as PreviousDesignation, payrollManagementDB.dbo.FDesignationName(NewDesigID) as NewDesignation, payrollManagementDB.dbo.FDepartmentName(PrevDepartID) as PreviousDepartment, payrollManagementDB.dbo.FDepartmentName(NewDepartID) as NewDepartment, payrollManagementDB.dbo.FEmployeeName(updatedBy) as UpdatedBy, updatedOn
	FROM EmployeesTable
	INNER JOIN PreviousDetails ON EmployeesTable.employeeID = PreviousDetails.employeeID
END

-- call the procedure
EXEC SPGetPreviousAndNewDetails

-- create Procedure to get designationID, employeeName who changed the salary, perDay, BonusPerHour, wasValidTill from the PreviousSalaryTable
CREATE PROCEDURE SPGetPreviousSalaryDetails
AS
BEGIN
	SELECT  payrollManagementDB.dbo.FDesignationName(designationID) as Designation, payrollManagementDB.dbo.FEmployeeName(changedBy) as UpdatedBy, perDay, BonusPerHour, wasValidTill
	FROM PreviousSalaryTable
	INNER JOIN EmployeesTable ON EmployeesTable.employeeID = PreviousSalaryTable.changedBy
END

-- call the procedure
EXEC SPGetPreviousSalaryDetails


-- Procedure to update the username and password of an employee
CREATE PROCEDURE SPUpdateUsernameAndPassword
@employeeID int,
@username varchar(50),
@password varchar(50)
AS
BEGIN
	UPDATE EmployeesTable SET username = @username, password = @password WHERE employeeID = @employeeID
END

-- call the procedure
EXEC SPUpdateUsernameAndPassword @employeeID = 1, @username = 'MD', @password = '1234'

-- EmployeeName, DepartmentName, DesignationName by using the employeeID
CREATE PROCEDURE SPGetEmployeeDetailsByEmployeeID
@employeeID int
AS
BEGIN
	SELECT employeeName, payrollManagementDB.dbo.FDepartmentName(employeeDepartment) as departmentName, payrollManagementDB.dbo.FDesignationName(employeeDesignation) as designationName
	FROM EmployeesTable
	WHERE employeeID = @employeeID and username = null and password = null
END

-- call the procedure
EXEC SPGetEmployeeDetailsByEmployeeID @employeeID = 5

-- Procedure to get EmployeeID, EmployeeName, DepartmentName, DesignationName who have set the username and password
CREATE PROCEDURE SPGetEmployeeDetailsByUserNameAndPassword
AS
BEGIN
	SELECT employeeID, employeeName, payrollManagementDB.dbo.FDepartmentName(employeeDepartment) as departmentName, payrollManagementDB.dbo.FDesignationName(employeeDesignation) as designationName, username
	FROM EmployeesTable
	WHERE username is not null and password is not null
END

-- call the procedure
EXEC SPGetEmployeeDetailsByUserNameAndPassword

-- procedure to set the username and password of an employee to null
CREATE PROCEDURE SPSetUsernameAndPasswordToNull
@employeeID int
AS
BEGIN
	UPDATE EmployeesTable SET username = null, password = null WHERE employeeID = @employeeID
END

-- call the procedure
EXEC SPSetUsernameAndPasswordToNull @employeeID = 5

-- Procedure to reset the username and password of an employee to their name
CREATE PROCEDURE SPResetUsernameAndPassword
@employeeID int
AS
BEGIN
	DECLARE @employeeName varchar(50)
	SELECT @employeeName = employeeName FROM EmployeesTable WHERE employeeID = @employeeID
	UPDATE EmployeesTable SET  password = @employeeName WHERE employeeID = @employeeID
END

-- call the procedure
EXEC SPResetUsernameAndPassword @employeeID = 3
select * from EmployeesTable


select * from PayrollTable

--Function to return MonthName by MonthNumber by if else
CREATE FUNCTION FMonthName(@monthNumber int)
RETURNS varchar(50)
AS
BEGIN
	DECLARE @monthName varchar(50)
	IF @monthNumber = 1
	BEGIN
		SET @monthName = 'January'
	END
	ELSE IF @monthNumber = 2
	BEGIN
		SET @monthName = 'February'
	END
	ELSE IF @monthNumber = 3
	BEGIN
		SET @monthName = 'March'
	END
	ELSE IF @monthNumber = 4
	BEGIN
		SET @monthName = 'April'
	END
	ELSE IF @monthNumber = 5
	BEGIN
		SET @monthName = 'May'
	END
	ELSE IF @monthNumber = 6
	BEGIN
		SET @monthName = 'June'
	END
	ELSE IF @monthNumber = 7
	BEGIN
		SET @monthName = 'July'
	END
	ELSE IF @monthNumber = 8
	BEGIN
		SET @monthName = 'August'
	END
	ELSE IF @monthNumber = 9
	BEGIN
		SET @monthName = 'September'
	END
	ELSE IF @monthNumber = 10
	BEGIN
		SET @monthName = 'October'
	END
	ELSE IF @monthNumber = 11
	BEGIN
		SET @monthName = 'November'
	END
	ELSE IF @monthNumber = 12
	BEGIN
		SET @monthName = 'December'
	END
	RETURN @monthName
END

-- call the function
SELECT payrollManagementDB.dbo.FMonthName(1)


SELECT employeeID, payrollManagementDB.dbo.FEmployeeName(employeeID) as employeeName, Year, payrollManagementDB.dbo.FMonthName(Month) as [Month], Date, Deduction, Bonus, TotalSalary FROM PayrollTable


-- procedure to get the emloyeeid ,employee name , designation name, department name ,employeeNic by using city name
CREATE PROCEDURE SPGetEmployeeDetailsByCityName
@cityName varchar(50)
AS
BEGIN
	SELECT employeeID, employeeName, payrollManagementDB.dbo.FDesignationName(employeeDesignation) as designationName, payrollManagementDB.dbo.FDepartmentName(employeeDepartment) as departmentName, employeeNic
	FROM EmployeesTable
	WHERE city = @cityName
END

EXEC SPGetEmployeeDetailsByCityName @cityName = 'Lahore'