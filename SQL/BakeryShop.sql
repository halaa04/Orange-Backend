CREATE DATABASE BakeryShop;
GO

USE BakeryShop;
GO

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20) NULL,
    Address NVARCHAR(255) NULL,
    IsDeleted BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);
-----------------------------------

CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,
    IsDeleted BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);
-------------------------------------

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryID INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT DEFAULT 0,
    IsDeleted BIT DEFAULT 0,
    CreatedAt  DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,

    CONSTRAINT FK_Products_Categories 
        FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

----- Categories (1) -----> (M) Product  ------

-----------------------------------------

CREATE TABLE Orders (
    OrderID  INT IDENTITY(1,1) PRIMARY KEY,
    UserID  INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status  NVARCHAR(50) DEFAULT 'Pending',
    IsDeleted BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,

    CONSTRAINT FK_Orders_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT CHK_Orders_Status
        CHECK (Status IN ('Pending', 'Confirmed', 'Delivered', 'Cancelled'))
);
--- Users (1) -----> (M) Ordersn ----

---------------------------------------

CREATE TABLE OrderItems (
    OrderItemID  INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity  INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    IsDeleted BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,

    CONSTRAINT FK_OrderItems_Orders
        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderItems_Products
        FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT CHK_OrderItems_Quantity
        CHECK (Quantity > 0)
);

--- Orders (1) -----> (M) OrderItems --
--- Products (1) -----> (M) OrderItems --

------------------------------------------------
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    Amount  DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    Status  NVARCHAR(50) DEFAULT 'Pending',
    IsDeleted  BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,

    CONSTRAINT FK_Payments_Orders
        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT CHK_Payments_Method
        CHECK (PaymentMethod IN ('Cash', 'Credit Card', 'Debit Card')),
    CONSTRAINT CHK_Payments_Status
        CHECK (Status IN ('Pending', 'Completed', 'Failed', 'Refunded'))
);

--- Orders (1) -----> (1) Payments ---

--------------------------------------------

CREATE TABLE Reviews (
    ReviewID  INT IDENTITY(1,1) PRIMARY KEY,
    UserID  INT NOT NULL,
    ProductID INT NOT NULL,
    Rating  INT NOT NULL,
    Comment   NVARCHAR(255) NULL,
    IsDeleted BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,

    CONSTRAINT FK_Reviews_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_Reviews_Products
        FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT CHK_Reviews_Rating
        CHECK (Rating BETWEEN 1 AND 5),
    CONSTRAINT UQ_Reviews_UserProduct
        UNIQUE (UserID, ProductID)
);

---- Users (1) -----> (M) Reviews ---
---- Products (1) -----> (M) Reviews  ---

-------------------------------------------
CREATE TABLE Wishlist (
    WishlistID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    ProductID  INT NOT NULL,
    IsDeleted  BIT DEFAULT 0,
    CreatedAt  DATETIME DEFAULT GETDATE(),
    UpdatedAt  DATETIME NULL,

    CONSTRAINT FK_Wishlist_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_Wishlist_Products
        FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT UQ_Wishlist_UserProduct
        UNIQUE (UserID, ProductID)
);

----------- create tables done ------------
INSERT INTO Categories (CategoryName) VALUES
('Cakes'),
('Pastries'),
('Cookies');

------- 
 INSERT INTO Users (FullName, Email, Phone, Address) VALUES
('Sara Ahmed',  'sara@email.com',  '0791234567', 'Amman, Jordan'),
('Omar Khalid', 'omar@email.com',  '0797654321', 'Irbid, Jordan'),
('Lina Nasser', 'lina@email.com',  '0795551234', 'Zarqa, Jordan');

---------
INSERT INTO Products (CategoryID, ProductName, Description, Price, Stock) VALUES
(2, 'Croissant Chocolate', 'Buttery croissant with chocolate filling', 2.50,  50),
(2, 'Cheese Pastry',  'Flaky pastry with creamy cheese', 3.00,  40),
(1, 'Chocolate Cake', 'Rich chocolate layered cake',    15.00, 20),
(1, 'Vanilla Cake',  'Light and fluffy vanilla cake',   13.00, 20),
(1, 'Cheesecake', 'Classic New York style cheesecake', 12.00, 15),
(3, 'Chocolate Chip Cookies', 'Crispy cookies with chocolate chips',   4.00,  60),
(3, 'Oatmeal Cookies','Healthy oatmeal cookies',  3.50,  60);

-------------
INSERT INTO Orders (UserID, TotalAmount, Status) VALUES
(1, 17.50, 'Confirmed'),
(2, 15.00, 'Delivered'),
(3,  7.50, 'Pending');

-----------------
INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice) VALUES
(1, 1, 2, 2.50),
(1, 3, 1, 15.00),
(2, 4, 1, 13.00),
(3, 6, 1, 4.00),
(3, 7, 1, 3.50);

-----------------------

INSERT INTO Payments (OrderID, Amount, PaymentMethod, Status) VALUES
(1, 17.50, 'Credit Card', 'Completed'),
(2, 15.00, 'Cash',        'Completed'),
(3,  7.50, 'Debit Card',  'Pending');

-------------------

INSERT INTO Reviews (UserID, ProductID, Rating, Comment) VALUES
(1, 3, 5, 'Amazing chocolate cake!'),
(2, 4, 4, 'Very tasty vanilla cake'),
(3, 6, 5, 'Best cookies ever!');

----------------------
INSERT INTO Wishlist (UserID, ProductID) VALUES
(1, 5),
(2, 1),
(3, 3);

--------------------------------------------------
UPDATE Products
SET Price = 4.00,
    UpdatedAt = GETDATE()
WHERE ProductID = 7; 

UPDATE Products
SET IsDeleted = 1,
    UpdatedAt = GETDATE()
WHERE ProductID = 2;

----------

SELECT 
    o.OrderID,
    u.FullName,
    u.Email,
    o.OrderDate,
    o.TotalAmount,
    o.Status
FROM Orders o
INNER JOIN Users u ON o.UserID = u.UserID
WHERE o.IsDeleted = 0;
-------------------------------------
SELECT 
    p.ProductName,
    c.CategoryName,
    p.Price,
    p.Stock
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE p.IsDeleted = 0
ORDER BY p.Price ASC;
---------------------------------------
SELECT 
    p.ProductName,
    COUNT(r.ReviewID) AS TotalReviews,
    AVG(CAST(r.Rating AS DECIMAL(3,2))) AS AvgRating
FROM Products p
LEFT JOIN Reviews r ON p.ProductID = r.ProductID
WHERE p.IsDeleted = 0
GROUP BY p.ProductName
ORDER BY AvgRating DESC;
--------------------------------------------
SELECT 
    u.FullName,
    p.ProductName,
    p.Price,
    w.CreatedAt AS AddedToWishlist
FROM Wishlist w
INNER JOIN Users u ON w.UserID = u.UserID
INNER JOIN Products p ON w.ProductID = p.ProductID
WHERE w.IsDeleted = 0
  AND u.UserID = 1;
-----------------------------------------------
SELECT 
    u.FullName,
    COUNT(o.OrderID) AS TotalOrders,
    SUM(o.TotalAmount) AS TotalSpent
FROM Users u
LEFT JOIN Orders o ON u.UserID = o.UserID
WHERE o.IsDeleted = 0
GROUP BY u.FullName
ORDER BY TotalSpent DESC;
------------------------------------------------
SELECT 
    p.ProductName,
    c.CategoryName,
    p.Price
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE p.IsDeleted = 0
  AND p.Price BETWEEN 3.00 AND 15.00
ORDER BY p.Price ASC;
------------------------------------------------
SELECT TOP 5
    o.OrderID,
    u.FullName,
    o.TotalAmount,
    o.Status,
    o.OrderDate
FROM Orders o
INNER JOIN Users u ON o.UserID = u.UserID
WHERE o.IsDeleted = 0
ORDER BY o.OrderDate DESC;
------------------------------------------------

CREATE INDEX IX_Products_CategoryID 
ON Products(CategoryID);

CREATE INDEX IX_Orders_UserID 
ON Orders(UserID);

CREATE INDEX IX_OrderItems_OrderID 
ON OrderItems(OrderID);