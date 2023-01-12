CREATE TABLE People(
 Id INT IDENTITY(1,1) UNIQUE,
 Name NVARCHAR(200) NOT NULL,
 Picture IMAGE,
 Height DECIMAL(3,2),
 Weight DECIMAL(5,2),
 Gender CHAR(1) NOT NULL,
 Birthdate DATE,
 Biography NVARCHAR(MAX),
 PRIMARY KEY(Id)
);

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
 ('Ivan', NULL, 1.50, 50.00, 'm', '2000-01-01', 'Bio'),
 ('Maria', NULL, 1.60, 60.00, 'f', '2001-01-01', 'Bio'),
 ('Georgi', NULL, 1.70, 70.00, 'm', '2002-01-01', 'Bio'),
 ('Dimitar', NULL, 1.80, 80.00, 'm', '2004-01-01', 'Bio'),
 ('Plamen', NULL, 1.90, 90.00, 'm', '2005-01-01', 'Bio')
 