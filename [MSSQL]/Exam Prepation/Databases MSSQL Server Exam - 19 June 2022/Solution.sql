--1
CREATE TABLE Owners
(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Address VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
    Id INT IDENTITY PRIMARY KEY,
    AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
    Id INT IDENTITY PRIMARY KEY,
    AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals
(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(30) NOT NULL,
    BirthDate DATE NOT NULL,
    OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
    AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages
(
    CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
    AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id),
    PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
    Id INT IDENTITY PRIMARY KEY,
    DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Address VARCHAR(50),
    AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
    DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

--2
INSERT INTO Volunteers
    (Name, PhoneNumber, Address, AnimalId, DepartmentId)
VALUES
    ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
    ('Dimitur Stoev', '0877564223', NULL, 42, 4),
    ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
    ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
    ('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals
    (Name, BirthDate, OwnerId, AnimalTypeId)
VALUES
    ('Giraffe', '2018-09-21', 21, 1),
    ('Harpy Eagle', '2015-04-17', 15, 3),
    ('Hamadryas Baboon', '2017-11-02', NULL, 1),
    ('Tuatara', '2021-06-30', 2, 4)

--3
UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL


--4
DELETE FROM Volunteers
WHERE DepartmentId = 2

DELETE FROM VolunteersDepartments
WHERE Id = 2

--5
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId
FROM Volunteers
ORDER BY Name, AnimalId, DepartmentId

--6
SELECT a.Name AS Name, at.AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
    JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
ORDER BY a.Name

--7
SELECT TOP(5)
    o.Name AS Owner, COUNT(a.Id) AS CountOfAnimals
FROM Owners AS o
    JOIN Animals AS a ON o.Id = a.OwnerId
GROUP BY o.Name
ORDER BY CountOfAnimals DESC, Owner

--8
SELECT CONCAT(o.Name, '-', a.Name) AS OwnersAnimals, o.PhoneNumber AS PhoneNumber, ac.CageId AS CageId
FROM Owners AS o
    JOIN Animals AS a ON o.Id = a.OwnerId
    JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
    JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
WHERE at.AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC

--9
SELECT Name, PhoneNumber, LTRIM((REPLACE(SUBSTRING(Address, 8, LEN(Address) - 6), ',', ''))) AS Address
FROM Volunteers
WHERE DepartmentId = 2 AND Address LIKE('%Sofia%')
ORDER BY Name

--10
SELECT e.Name, YEAR(e.BirthDate) AS BirthYear, et.AnimalType
FROM Animals AS e
    JOIN AnimalTypes AS et ON e.AnimalTypeId = et.Id
WHERE e.OwnerId IS NULL AND DATEDIFF(YEAR, e.BirthDate, '2022-01-01') < 5 AND e.AnimalTypeId != 3
ORDER BY e.Name

--11
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(50))
RETURNS INT
AS
BEGIN
    RETURN
    ( 
    SELECT COUNT(v.Id)
    FROM Volunteers AS v
        JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
    WHERE vd.DepartmentName = @VolunteersDepartment
    GROUP BY v.DepartmentId
    )
END

--12
GO
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(50))
AS
BEGIN
    SELECT
        a.Name,
        CASE
         WHEN
         a.OwnerId IS NULL THEN 'For adoption'
         ELSE o.Name
        END AS OwnersName

    FROM Animals AS a
        LEFT JOIN Owners AS o ON a.OwnerId = o.Id
    WHERE @AnimalName = a.Name
END

EXEC usp_AnimalsWithOwnersOrNot 'Hippo'

