CREATE DATABASE SoftUni;
USE SoftUni;

CREATE TABLE Towns(
    Id INT IDENTITY(1,1),
    Name NVARCHAR(30) NOT NULL,
    PRIMARY KEY(Id)
);

CREATE TABLE Addresses(
    Id INT IDENTITY(1,1),
    AddressText NVARCHAR(100) NOT NULL,
    TownId INT,
    PRIMARY KEY(Id),
    FOREIGN KEY(TownId) REFERENCES Towns(Id)
);

CREATE TABLE Departments(
    Id INT IDENTITY(1,1),
    Name NVARCHAR(30) NOT NULL,
    PRIMARY KEY(Id)
);

CREATE TABLE Employees(
    Id INT IDENTITY(1,1),
    FirstName NVARCHAR(30) NOT NULL,
    MiddleName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    JobTitle NVARCHAR(50) NOT NULL,
    DepartmentId INT NOT NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(7,2) NOT NULL,
    AddressId INT NOT NULL,
    PRIMARY KEY(Id),
    FOREIGN KEY(DepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY(AddressId) REFERENCES Addresses(Id)    
);
