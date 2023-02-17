CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Locations(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Municipality VARCHAR(50),
Province VARCHAR(50)
)

CREATE TABLE Sites(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
LocationId INT NOT NULL FOREIGN KEY REFERENCES Locations(Id),
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
Establishment VARCHAR(15)
)

CREATE TABLE Tourists(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Age INT NOT NULL
	CHECK (Age >= 0 AND Age <= 120),
PhoneNumber VARCHAR(20) NOT NULL,
Nationality VARCHAR(30) NOT NULL,
Reward VARCHAR(20)
)
   
CREATE TABLE SitesTourists(
TouristId INT NOT NULl FOREIGN KEY REFERENCES Tourists(Id),
SiteId INT NOT NULL FOREIGN KEY REFERENCES Sites(Id),
PRIMARY KEY(TouristId, SiteId)  
)

CREATE TABLE BonusPrizes(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes(
TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
BonusPrizeId INT NOT NULL FOREIGN KEY REFERENCES BonusPrizes(Id),
PRIMARY KEY(TouristId, BonusPrizeId),  
)

INSERT INTO Tourists VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites VALUES
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = 5

DELETE FROM BonusPrizes
WHERE Id = 5

SELECT Name, Age, PhoneNumber, Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, Name

SELECT S.Name AS Site, l.Name AS Location, s.Establishment, c.Name AS Category
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
JOIN Categories AS c ON s.CategoryId = c.Id
ORDER BY c.Name DESC, l.Name, s.Name

SELECT l.Province, l.Municipality, l.Name AS Location, COUNT(s.Id) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s ON l.Id = s.LocationId
WHERE l.Province = 'Sofia'
GROUP BY l.Province, l.Municipality, l.Name
ORDER BY CountOfSites DESC, l.Name

SELECT s.Name AS 'Site', l.Name AS 'Location', l.Municipality, l.Province, s.Establishment
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
WHERE l.Name IS NOT NULL AND 
LEFT(l.Name, 1) NOT IN('B', 'M', 'D') AND
s.Establishment LIKE ('%BC')
ORDER BY s.Name

SELECT t.Name, t.Age, t.PhoneNumber, t.Nationality, ISNULL(bp.Name, '(no bonus prize)') AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tbp ON t.Id = tbp.TouristId
LEFT JOIN BonusPrizes AS bp ON tbp.BonusPrizeId = bp.Id
ORDER BY t.Name


