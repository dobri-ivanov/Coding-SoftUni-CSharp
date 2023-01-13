CREATE TABLE Users(
 Id INT IDENTITY(1,1) UNIQUE,
 Username VARCHAR(30) NOT NULL UNIQUE,
 Password VARCHAR(26) NOT NULL,
 ProfilePicture IMAGE,
 LastLoginTime DATETIME,
 IsDeleted BIT
);

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
 ('user', 'pass', NULL, '2022-01-01', 0),
 ('user2', 'pass', NULL, '2022-01-01', 0),
 ('user3', 'pass', NULL, '2022-01-01', 0),
 ('user4', 'pass', NULL, '2022-01-01', 0),
 ('user5', 'pass', NULL, '2022-01-01', 0);