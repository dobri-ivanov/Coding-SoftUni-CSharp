CREATE TABLE Majors
(
    MajorID INT NOT NULL,
    Name VARCHAR(50) NOT NULL,
    PRIMARY KEY(MajorID)
)


CREATE TABLE Subjects
(
    SubjectID INT NOT NULL,
    SubjectName VARCHAR(50) NOT NULL,
    PRIMARY KEY(SubjectID)
)

CREATE TABLE Students
(
    StudentID INT NOT NULL,
    StudentNumber INT NOT NULL,
    StudentName VARCHAR(50) NOT NULL,
    MajorID INT,
    PRIMARY KEY(StudentID),
    FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Agends
(
    StudentID INT,
    SubjectID INT,
    PRIMARY KEY(StudentID, SubjectID),
    FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments
(
    PaymentID INT NOT NULL,
    PaymentDate DATE NOT NULL,
    PaymentAmount DECIMAL(6,2),
    StudentID INT,
    PRIMARY KEY(PaymentID),
    FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
)

