-- DDL TASK -- 

CREATE DATABASE onlineStore;
USE onlineStore;

---------------
CREATE TABLE Users (
user_id INT PRIMARY KEY,
name NVARCHAR(20) );

----------------
ALTER TABLE Users
ADD email NVARCHAR(25) UNIQUE;

-----------------
ALTER TABLE Users 
ALTER COLUMN email NVARCHAR(25) NOT NULL;
-----------------
CREATE TABLE Products (
name NVARCHAR(20) NOT NULL,
price DECIMAL(4,2) NOT NULL);

------------------
CREATE TABLE Orders(
order_id INT PRIMARY KEY,
user_id INT,
CONSTRAINT fk_orders_user_id FOREIGN KEY (user_id) REFERENCES Users(user_id));
-------------------
ALTER TABLE Orders
ADD date DATE;

-----------------
ALTER TABLE Orders
ADD CONSTRAINT df_orders_date
DEFAULT GETDATE() FOR date;

------------------
CREATE TABLE ProductsAndOrders(
product_id INT NOT NULL,
order_id INT NOT NULL,
CONSTRAINT pk_ProductsAndOrders PRIMARY KEY (product_id,order_id));

-------------------
CREATE TABLE Categories(
category_id INT PRIMARY KEY,
name NVARCHAR(15) NOT NULL);

ALTER TABLE Products
ADD category_id INT;

ALTER TABLE Products
ADD CONSTRAINT fk_products_categoryID
FOREIGN KEY (category_id) REFERENCES Categories(category_id); 

---------------------
CREATE TABLE Employees(
employee_id INT PRIMARY KEY,
name NVARCHAR(15),
manager_id INT,
CONSTRAINT fk_employees_managerID FOREIGN KEY (manager_id) REFERENCES Employees(employee_id));

----------------
ALTER TABLE Users
ADD phone INT;

ALTER TABLE Users
DROP COLUMN phone;

---------------
ALTER TABLE Users
ALTER COLUMN name NVARCHAR(30);

----------------
CREATE TABLE Customers(
customer_id INT PRIMARY KEY,
name NVARCHAR(15) NOT NULL,
phone INT );

-----------------
CREATE TABLE Payments(
payment_id INT PRIMARY KEY,
order_id INT,
CONSTRAINT fk_payments_orderID FOREIGN KEY (order_id) REFERENCES Orders(order_id));

------------------
CREATE TABLE Students(
Std_id INT PRIMARY KEY,
name NVARCHAR(15) NOT NULL);

------------------
CREATE TABLE Courses(
course_id INT PRIMARY KEY,
title NVARCHAR(25) );

--------------------
CREATE TABLE Enrollment(
student_id INT,
course_id INT,
CONSTRAINT pk_enrollment PRIMARY KEY (student_id, course_id),
CONSTRAINT fk_enrollment_studentID FOREIGN KEY (student_id) REFERENCES Students(Std_id),
CONSTRAINT fk_enrollemtn_course_id FOREIGN KEY (course_id) REFERENCES Courses(course_id));

------------------
CREATE TABLE Logs(
log_id INT PRIMARY KEY,
message NVARCHAR(30),
timestamp DATETIME
);

----------------
TRUNCATE TABLE Logs;

----------------
ALTER TABLE Logs
DROP COLUMN timestamp;

----------------
DROP TABLE Enrollment;

---------
CREATE TABLE NewTable(
table_id INT IDENTITY PRIMARY KEY,
name NVARCHAR(10));

-------------
CREATE TABLE TestTable(
table_id INT PRIMARY KEY,
must INT NOT NULL,
optional INT);

--------------
CREATE TABLE Books(
title NVARCHAR(30) PRIMARY KEY,
price DECIMAL(3,2));

---------------
CREATE TABLE Author(
author_id INT PRIMARY KEY,
author_name NVARCHAR(20));

------------------
ALTER TABLE Books 
ADD author_id INT;

ALTER TABLE Books
ADD CONSTRAINT fk_books_author FOREIGN KEY (author_id) REFERENCES Author(author_id);

--------------
CREATE TABLE IdsTable(
order_id INT,
employee_id INT,
category_id INT,
CONSTRAINT pk_IdsTable PRIMARY KEY (order_id,employee_id,category_id),
CONSTRAINT fk_IdsTable_order_id FOREIGN KEY (order_id) REFERENCES Orders(order_id),
CONSTRAINT fk_IdsTable_employee_id FOREIGN KEY (employee_id) REFERENCES Employees(employee_id),
CONSTRAINT fk_IdsTable_category_id FOREIGN KEY (category_id) REFERENCES Categories(category_id));

---------------
CREATE TABLE AllTable(
TableID INT PRIMARY KEY,
names NVARCHAR(20),
dates DATE);

----------------
CREATE TABLE AllTable2(
TableID INT PRIMARY KEY,
names NVARCHAR(20),
dates DATE);

ALTER TABLE AllTable2
ADD CONSTRAINT uq_AllTable_names UNIQUE (names);


