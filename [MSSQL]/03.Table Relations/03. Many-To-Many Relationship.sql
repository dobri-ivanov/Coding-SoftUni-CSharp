CREATE TABLE Students
(
    StudentID INT IDENTITY(1, 1),
    Name VARCHAR(25) NOT NULL,
    PRIMARY KEY(StudentID)
)

DROP DATABASE Geography
CREATE TABLE Exams
(
    ExamID INT IDENTITY(101, 1),
    Name VARCHAR(25) NOT NULL,
    PRIMARY KEY(ExamID)
)

CREATE TABLE StudentsExams
(
    StudentID INT NOT NULL
     FOREIGN KEY REFERENCES Students(StudentID),
    ExamID INT NOT NULL
     FOREIGN KEY REFERENCES Exams(ExamID),
    PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students
VALUES
    ('Mila'),
    ('Toni'),
    ('Ron');

INSERT INTO Exams
VALUES
    ('SpringMVC'),
    ('Neo4j'),
    ('Oracle 11g');

INSERT INTO StudentsExams
VALUES
    (1, 101),
    (1, 102),
    (2, 101)
    