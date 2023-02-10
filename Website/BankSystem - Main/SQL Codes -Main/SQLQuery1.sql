Create database BankSystem
go 

use BankSystem
go

CREATE TABLE Customer (
Id int IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(100),
SSN varchar(14)NOT NULL,
DOB DATE,
Phone VARCHAR(12),
Email VARCHAR(50),
Address VARCHAR(200),
Username VARCHAR(20),
Password VARCHAR(20),
PIN NUMERIC(4),
Reg_Date DATETIME
)

CREATE TABLE Branch (
Id int IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(20),
Address VARCHAR(100),
CUSIP VARCHAR(10),
Phone VARCHAR(16)
)

CREATE TABLE LastL(
id int identity(1,1)primary key,
 PIN numeric(4)
)

CREATE TABLE Account (
Id int IDENTITY(1,1) PRIMARY KEY,
AccNumber VARCHAR(12),
AccType VARCHAR(10),
Reg_Date DATETIME,
Balance FLOAT(8),
CustId int FOREIGN KEY REFERENCES Customer(Id),
BranchId int FOREIGN KEY REFERENCES Branch(Id)
)

CREATE TABLE Transactions (
Id int IDENTITY(1,1) PRIMARY KEY,
TranDate DATETIME,
Amount FLOAT(8),
TranType VARCHAR(10),
AccId int FOREIGN KEY REFERENCES Account(Id)
)

INSERT INTO Branch VALUES ('New York', '5th Avenue', 'NY001USA', '1-888-397-1980')
INSERT INTO Branch VALUES ('Chicago', '1849 W Madison St', 'CHI002USA', '1-888-397-1980')
INSERT INTO Branch VALUES ('Log Angeles', '801 S Grand Ave 510', 'LA003USA', '1-888-397-1980')
INSERT INTO Branch VALUES ('Washington D.C', '1615 L Street NW 340', 'WA004USA', '1-202-429-0222')
INSERT INTO Branch VALUES ('Dallas', '801 E Campbell Rd 585', 'DA005USA', '1-214-445-0600')
INSERT INTO Branch VALUES ('Miami', '1500 NW 136th Ave', 'MIA006USA', '1-954-503-0000')


SELECT * FROM Branch
select * from Account
select * from Customer


UPDATE Account SET Balance = 500000

--banksoftwarengineering