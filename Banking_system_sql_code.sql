Create database Banking_system
go 

use Banking_system
go

Create table Bank(
Bank_id varchar(5),
Bank_name varchar(15),
Bank_address varchar(50),
Bank_email varchar(25),
primary key (Bank_id) 
);

Create table Branch(
Branch_id varchar(5),
Branch_name varchar(20),
Branch_address varchar(50),
primary key (Branch_id,Branch_name)
);

Create table Customer(
Customer_id varchar(10),
Customer_name varchar(10),
Customer_surname varchar(10),
Customer_city varchar(10),
Customer_address varchar(50),
primary key (Customer_id) 
);

Create table Loan(
Loan_id varchar(10),
Amount numeric(15,2),
Branch_name varchar(20),
Branch_id varchar(5),
primary key(Loan_id),
foreign key (Branch_id,Branch_name) references Branch

);

Create table Credit_Card(
Credit_card_id varchar(16),
Expire_date date,
Limit numeric(10,2),
CCV numeric(3),
primary key (Credit_card_id)
);

Create table Account(
Account_id varchar(16),
Balance numeric(15),
Category varchar(15),
CCV numeric(3),
Expire_date date,
primary key (Account_id)

);

Create table Borrower(
Customer varchar(10),
Loan_id varchar(10),
foreign key (Customer) references Customer,
foreign key (Loan_id) references Loan
);

Create table Customer_credit_card(
Customer varchar(10),
Credit_card_id varchar(16),
Account_id varchar(16),
foreign key (Customer) references Customer,
foreign key (Credit_card_id) references Credit_Card,
foreign key (Account_id) references Account
);

Create table Banker(
Branch_id varchar(5),
Customer_id varchar(10),
Bank_id varchar(5),
foreign key (Branch_id) references Bank,
foreign key (Customer_id) references Customer,
foreign key (Bank_id)references Bank
);