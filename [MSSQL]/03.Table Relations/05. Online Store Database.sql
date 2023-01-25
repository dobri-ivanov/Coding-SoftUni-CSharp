CREATE TABLE Cities
(
    CityID INT IDENTITY(1, 1),
    Name VARCHAR(25) NOT NULL,
    PRIMARY KEY(CityID)
)

CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1, 1),
    Name VARCHAR(25) NOT NULL,
    Birthday DATETIME,
    CityID INT,
    PRIMARY KEY(CustomerID),
    FOREIGN KEY(CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
    OrderID INT IDENTITY(1, 1),
    CustomerID INT,
    PRIMARY KEY(OrderID),
    FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
    ItemTypeID INT IDENTITY(1, 1),
    NAME VARCHAR(25) NOT NULL,
    PRIMARY KEY(ItemTypeID)
)

CREATE TABLE Items 
(
    ItemID INT IDENTITY(1, 1),
    Name VARCHAR(25) NOT NULL,
    ItemTypeID INT,
    PRIMARY KEY(ItemID),
    FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
    OrderID INT,
    ItemID INT,
    PRIMARY KEY(OrderID, ItemID),
    FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY(ItemID) REFERENCES Items(ItemID)
)