CREATE DATABASE GymDB;
GO

USE GymDB;
GO

-- 1. Members Table
CREATE TABLE Members (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL
);

INSERT INTO Members (FullName, Email, Phone) 
VALUES ('Lishanth Babu', 'member@example.com', '9876543210');

-- 2. Membership Plans Table
CREATE TABLE Plans (
    PlanID INT IDENTITY(1,1) PRIMARY KEY,
    PlanName VARCHAR(100) NOT NULL,
    DurationMonths INT NOT NULL,
    FeeAmount DECIMAL(10,2) NOT NULL,
    Description VARCHAR(255)
);

INSERT INTO Plans (PlanName, DurationMonths, FeeAmount, Description) VALUES
('Monthly Basic', 1, 1200.00, 'Standard gym floor and cardio equipment access'),
('Quarterly Fitness', 3, 3200.00, 'Gym access + locker facility + trainer guidance'),
('Half-Yearly Pro', 6, 6000.00, 'All facilities + steam bath + diet consultation'),
('Annual VIP', 12, 10500.00, 'Unlimited all-access annual pass + personal locker');

-- 3. Fee Payments Table
CREATE TABLE FeePayments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    MemberID INT FOREIGN KEY REFERENCES Members(MemberID),
    PlanID INT FOREIGN KEY REFERENCES Plans(PlanID),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalPaid DECIMAL(10,2) NOT NULL,
    PaymentMode VARCHAR(50) NOT NULL,
    PaymentStatus VARCHAR(50) DEFAULT 'Paid',
    PaymentDate DATETIME DEFAULT GETDATE()
);
GO