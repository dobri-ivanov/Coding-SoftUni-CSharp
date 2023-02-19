CREATE TABLE Categories
(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT IDENTITY PRIMARY KEY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town VARCHAR(30) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(30) UNIQUE NOT NULL,
    AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id),
    Website NVARCHAR(40),
    Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges
(
    Id INT IDENTITY PRIMARY KEY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(2,1) NOT NULL,
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(Id),
    PlayersRangeId INT NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators
(
    Id INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
    CreatorId INT NOT NULL FOREIGN KEY REFERENCES Creators(Id),
    BoardgameId INT NOT NULL FOREIGN KEY REFERENCES Boardgames(Id),
    PRIMARY KEY(CreatorId, BoardgameId)
)

--2
INSERT INTO Boardgames
    (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
    ('Deep Blue', '2019', 5.67, 1, 15, 7),
    ('Paris', '2016', 9.78, 7, 1, 5),
    ('Catan: Starfarers', '2021', 9.87, 7, 13, 6),
    ('Bleeding Kansas', '2020', 3.25, 3, 7, 4),
    ('One Small Step', '2019', 5.75, 5, 9, 2)

INSERT INTO Publishers
    (Name, AddressId, Website, Phone)
VALUES
    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

--3
UPDATE PlayersRanges
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET Name = Name + 'V2'
WHERE YearPublished >= 2020


--4
SELECT *
FROM Publishers
WHERE AddressId = 5

SELECT *
FROM Addresses
WHERE LEFT(Town, 1) = 'l'

SELECT *
FROM Boardgames
WHERE PublisherId IN (1, 16)

DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (1, 16, 31, 47)

DELETE FROM Boardgames
WHERE PublisherId IN (1, 16)

DELETE FROM Publishers
WHERE AddressId = 5

DELETE FROM Addresses
WHERE LEFT(Town, 1) = 'L'

--5
SELECT Name, Rating
FROM Boardgames
ORDER BY YearPublished, Name DESC

--6
SELECT b.Id, b.Name, b.YearPublished, c.Name AS CategoryName
FROM Boardgames AS b
    JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC

--7
SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName, c.Email
FROM Creators AS c
    LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
    LEFT JOIN Boardgames AS b ON cb.BoardgameId = b.Id
WHERE BoardgameId IS NULL

--8
SELECT TOP(5)
    b.Name, b.Rating, c.Name AS CategoryName
FROM Boardgames AS b
    JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
    JOIN Categories AS c ON b.CategoryId = c.Id
WHERE 
    (b.Rating > 7.00 AND b.Name LIKE('%a%')) OR
    (b.Rating > 7.50 AND (pr.PlayersMin = 2 AND pr.PlayersMax = 5))
ORDER BY b.Name, b.Rating DESC

--9
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, c.Email, MAX(b.Rating) AS Rating
FROM Creators AS c
    JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
    JOIN Boardgames AS b ON b.Id = cb.BoardgameId
WHERE c.Email LIKE('%.com')
GROUP BY c.FirstName, c.LastName, c.Email

--10
SELECT c.LastName, CEILING(AVG(b.Rating)) AS AverageRating, p.Name AS PublisherName
FROM Creators AS c
    JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
    JOIN Boardgames AS b ON b.Id = cb.BoardgameId
    JOIN Publishers AS p ON b.PublisherId = p.Id
WHERE p.Name = 'Stonemaier Games'
GROUP BY c.LastName, p.Name
ORDER BY AVG(b.Rating) DESC

--11
CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(50))
RETURNS INT
AS
BEGIN
    RETURN
    (
    SELECT COUNT(b.Id)
    FROM Creators AS c
        JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
        JOIN Boardgames AS b ON b.Id = cb.BoardgameId
    WHERE c.FirstName = @name
    GROUP BY c.Id
    )
END

--12
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(100))
AS
BEGIN
    SELECT
        b.Name AS Name,
        b.YearPublished,
        b.Rating,
        c.Name AS CategoryName,
        p.Name AS PublisherName,
        CONCAT(pr.PlayersMin, ' people') AS MinPlayers,
        CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
    FROM Boardgames AS b
        JOIN Categories AS c ON b.CategoryId = c.Id
        JOIN Publishers AS p ON b.PublisherId = p.Id
        JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
    WHERE c.Name = @category
    ORDER BY p.Name, b.YearPublished DESC
END

