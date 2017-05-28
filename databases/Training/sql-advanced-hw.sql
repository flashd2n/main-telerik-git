USE TelerikAcademy

---Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
-----Use a nested SELECT statement.

SELECT FirstName, LastName, Salary FROM Employees
	WHERE Salary = (SELECT MIN(Salary) FROM Employees)

---Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT FirstName, LastName, Salary FROM Employees
	WHERE Salary BETWEEN (SELECT MIN(Salary) FROM Employees)
				 AND (SELECT MIN(Salary) + (SELECT MIN(Salary) / 10) FROM Employees)

---Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
-----Use a nested SELECT statement.

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, e.DepartmentID FROM Employees e
	WHERE Salary = (SELECT MIN(Salary) FROM Employees
						WHERE e.DepartmentID = DepartmentID)

---Write a SQL query to find the average salary in the department #1.

SELECT AVG(Salary) FROM Employees
	WHERE DepartmentID = 1

---Write a SQL query to find the average salary in the "Sales" department.

SELECT AVG(e.Salary) FROM Employees e
	INNER JOIN Departments d 
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

---Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(*) FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

---Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(ManagerID) FROM Employees

---Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*) FROM Employees
	WHERE ManagerID IS NULL

---Write a SQL query to find all departments and the average salary for each of them.

SELECT e.DepartmentID, d.Name, AVG(Salary) AS [Average Salary] FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	GROUP BY e.DepartmentID, d.Name

---Write a SQL query to find the count of all employees in each department and for each town.

SELECT COUNT(*) AS [Count of Emp], d.Name AS [Department], t.Name AS [Town] FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
	GROUP BY d.Name, t.Name

---Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

SELECT COUNT(*) AS [Number of Employees], m.FirstName, m.LastName FROM Employees e
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	GROUP BY m.FirstName, m.LastName
	HAVING COUNT(*) = 5

---Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT e.FirstName + ' ' + e.LastName AS [Employee], ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager] FROM Employees e
	LEFT JOIN Employees m
	ON e.ManagerID = m.EmployeeID

---Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT FirstName + ' ' + LastName FROM Employees
	WHERE LEN(LastName) = 5

---Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
-----Search in Google to find how to format dates in SQL Server.

SELECT CONVERT(nvarchar, GETDATE(), 104) + ' ' + CONVERT(nvarchar, GETDATE(), 114) AS [Current Time]

---Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
-----Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
-----Define the primary key column as identity to facilitate inserting records.
-----Define unique constraint to avoid repeating usernames.
-----Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users(
	Id int IDENTITY,
	Username nvarchar(50) NOT NULL,
	Password nvarchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLogin smalldatetime NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY(Id),
	CONSTRAINT UC_Users UNIQUE (Username),
	CONSTRAINT CHK_Users CHECK (LEN(Password) >= 5)
)
GO

---Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
-----Test if the view works correctly.

CREATE VIEW [Logged Today] AS
	SELECT Username, FullName
	FROM Users
	WHERE CONVERT(nvarchar, LastLogin, 104) = CONVERT(nvarchar, GETDATE(), 104)

SELECT * FROM [Logged Today]

---Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
-----Define primary key and identity column.

CREATE TABLE Groups(
	Id int IDENTITY,
	Name nvarchar(50),
	CONSTRAINT PK_Groups PRIMARY KEY(Id),
	CONSTRAINT UC_Groups UNIQUE(Name)
)
GO

---Write a SQL statement to add a column GroupID to the table Users.
-----Fill some data in this new column and as well in the Groups table.
-----Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

ALTER TABLE Users
	ADD GroupID int NOT NULL

INSERT INTO Users (Username, Password, FullName, LastLogin, GroupID)
	VALUES ('flash', 'blqqqq11', 'Kalin Kostov', '1998-07-31 00:00:00', 1)

INSERT INTO Groups VALUES ('Awesomeness')

ALTER TABLE Users
	ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupID) REFERENCES Groups

---Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Users (Username, Password, FullName, LastLogin, GroupID)
	VALUES ('walis', 'blqqqq11', 'Pesho Kostov', '1998-07-31 00:00:00', 1)

INSERT INTO Users (Username, Password, FullName, LastLogin, GroupID)
	VALUES ('waliss', 'blqqqq11', 'Pesho Kostov', '1998-07-31 00:00:00', 1)

INSERT INTO Users (Username, Password, FullName, LastLogin, GroupID)
	VALUES ('walisss', 'blqqqq11', 'Pesho Kostov', '1998-07-31 00:00:00', 1)

INSERT INTO Groups VALUES ('Coolness')
INSERT INTO Groups VALUES ('SQL Sucks')
INSERT INTO Groups VALUES ('HEEELP')

---Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
	SET Password = 'sukaa11'
	WHERE Id BETWEEN 2 AND 4

---Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM Users
	WHERE Id BETWEEN 3 AND 4

---Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-----Combine the first and last names as a full name.
-----For username use the first letter of the first name + the last name (in lowercase).
-----Use the same for the password, and NULL for last login time.


INSERT INTO Users (Username, Password, FullName)
	SELECT LEFT(FirstName, 1) + LastName, LOWER(LEFT(FirstName, 1) + LastName + '12345'), FirstName + ' ' + LastName
	FROM Employees


---Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

UPDATE Users
	SET Password = NULL
	WHERE LastLogin < '2010-03-10'

---Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM Users
	WHERE Password IS NULL

---Write a SQL query to display the average employee salary by department and job title.

SELECT AVG(Salary) AS [Average Salary], DepartmentID, JobTitle FROM Employees
	GROUP BY DepartmentID, JobTitle
ORDER BY DepartmentID

---Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

SELECT COUNT(*) AS [Number of Employees],
	   MIN(Salary) AS [Minimal Salary],
	   DepartmentID,
	   JobTitle,
	   ExampleEmployee = (SELECT TOP 1 FirstName + ' ' + LastName FROM Employees e WHERE e.Salary = MIN(m.Salary) AND e.JobTitle = m.JobTitle)
	FROM Employees m
	GROUP BY DepartmentID, JobTitle
ORDER BY DepartmentID

---Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 COUNT(*) AS [Number of Employees], t.Name FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns t
	ON a.TownID = t.TownID
	GROUP BY t.Name
	ORDER BY COUNT(*) DESC

---Write a SQL query to display the number of managers from each town.

SELECT COUNT(DISTINCT m.EmployeeID) AS [Managers Count], t.Name FROM Employees e
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a
	ON m.AddressID = a.AddressID
	INNER JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY t.Name

---Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
-----Don't forget to define identity, primary key and appropriate foreign key.
-----Issue few SQL statements to insert, update and delete of some data in the table.
-----Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
-----For each change keep the old record data, the new record data and the command (insert / update / delete).

