Create database BankSystem
go 

use BankSystem
go

CREATE TABLE Customer (
Id int IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(100),
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
CREATE TABLE LastL(
int id identity(1,1)primary key,
numeric(4) PIN
)
INSERT INTO Branch VALUES ('New York', '5th Avenue', 'SBIN007000', '1-888-397-1980')
INSERT INTO Branch VALUES ('Chicago', '1849 W Madison St', 'SBIN000080', '1-888-397-1980')
INSERT INTO Branch VALUES ('Log Angeles', '801 S Grand Ave 510', 'SBIN000069', '1-888-397-1980')
SELECT * FROM Branch






