USE TSQLHW

---Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
-----Insert few records for testing.
-----Write a stored procedure that selects the full names of all persons.

CREATE TABLE People(
	Id int IDENTITY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL,
	CONSTRAINT PK_People Primary KEY(Id)
)
GO

CREATE TABLE Accounts(
	Id int IDENTITY,
	Balance money,
	PersonID int,
	CONSTRAINT PK_Accounts Primary KEY(Id),
	CONSTRAINT FK_Accounts_People FOREIGN KEY (PersonId) REFERENCES People
)
GO

INSERT INTO People (FirstName, LastName, SSN) VALUES ('Gosho', 'Goshev', 'gosho11')
GO
INSERT INTO People (FirstName, LastName, SSN) VALUES ('Ivan', 'Ivanov', 'ivan11')
GO
INSERT INTO People (FirstName, LastName, SSN) VALUES ('Tosho', 'Toshev', 'tosho11')
GO
INSERT INTO People (FirstName, LastName, SSN) VALUES ('Mariika', 'Mariikova', 'mariika11')
GO
INSERT INTO People (FirstName, LastName, SSN) VALUES ('Stamat', 'Stamatov', 'Stamat11')
GO
INSERT INTO Accounts (Balance, PersonID) VALUES (10000, 5)
GO
INSERT INTO Accounts (Balance, PersonID) VALUES (20000, 4)
GO
INSERT INTO Accounts (Balance, PersonID) VALUES (30000, 3)
GO
INSERT INTO Accounts (Balance, PersonID) VALUES (40000, 2)
GO
INSERT INTO Accounts (Balance, PersonID) VALUES (50000, 1)
GO

CREATE PROC usp_GetFullNamesPeople
AS
	BEGIN
		SELECT FirstName + ' ' + LastName AS [Full Name] FROM People
	END

EXEC usp_GetFullNamesPeople

GO
---Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

CREATE PROC usp_GetRichPeople @accountBalance money
AS
	BEGIN
		SELECT p.FirstName + ' ' + p.LastName AS [Full Name] FROM People p
			INNER JOIN Accounts a
			ON a.PersonID = p.Id
			WHERE a.Balance > @accountBalance
	END

EXEC usp_GetRichPeople 25000

GO

---Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-----It should calculate and return the new sum.
-----Write a SELECT to test whether the function works as expected.

CREATE FUNCTION ufn_CalculateSum (@sum money, @interestRate float, @monthsCount int)
	RETURNS money
	AS
		BEGIN
			SET @interestRate = @interestRate / 100
			SET @sum = @sum + (@sum * @interestRate * @monthsCount)
			RETURN @sum
		END

SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance, dbo.ufn_CalculateSum(a.Balance, 1.2, 12) AS [Balance After One Year] FROM People p
	INNER JOIN Accounts a
	ON a.PersonID = p.Id



---Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
-----It should take the AccountId and the interest rate as parameters.

CREATE PROC usp_GetOneMonthReturn @accountId int, @interestRate float
	AS
		BEGIN
			SELECT p.FirstName + ' ' + p.LastName AS [Full Name], dbo.ufn_CalculateSum(a.Balance, @interestRate, 1) AS [One Month Return] FROM People p
				INNER JOIN Accounts a
				ON a.PersonID = p.Id
				WHERE a.PersonID = @accountId
		END

EXEC usp_GetOneMonthReturn 2, 1.2

---Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.

ALTER PROC usp_WithdrawMoney @accountId int, @money money
AS
	BEGIN
		BEGIN TRAN
		DECLARE @currentBalance money

		SELECT @currentBalance = Balance FROM Accounts
			WHERE Id = @accountId
		
		IF(@currentBalance >= @money)
			BEGIN
				UPDATE Accounts
					SET Balance = Balance - @money
					WHERE Id = @accountId
					COMMIT TRAN
			END
		ELSE
			BEGIN
				PRINT('Not Enough Money')
				ROLLBACK TRAN
			END
	END

EXEC usp_WithdrawMoney 2, 5000

CREATE PROC usp_DepositMoney @accountId int, @money money
AS
	BEGIN
		BEGIN TRAN
		UPDATE Accounts
				SET Balance = Balance + @money
				WHERE Id = @accountId
				COMMIT TRAN
	END

---Create another table – Logs(LogID, AccountID, OldSum, NewSum).
------Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

CREATE TABLE Logs(
	Id int IDENTITY,
	AccountId int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL
)
GO

CREATE TRIGGER utr_LogBalanceChange ON Accounts
	AFTER UPDATE
	AS
		BEGIN
			DECLARE @oldBalance money
			DECLARE @newBalance money
			DECLARE @account int
			
			SELECT @oldBalance = Balance FROM DELETED
			SELECT @newBalance = Balance FROM INSERTED
			SELECT @account = Id FROM DELETED

			INSERT INTO Logs (AccountId, OldSum, NewSum) VALUES (@account, @oldBalance, @newBalance)

		END

EXEC usp_DepositMoney 2, 20000

---Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
-----Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
GO
USE TelerikAcademy
GO

ALTER FUNCTION ufn_CheckLetters(@word nvarchar(50), @pattern nvarchar(50))
	RETURNS int
	AS
		BEGIN
			DECLARE @index int = 1
			DECLARE @currentChar nvarchar
			DECLARE @wordLength int = LEN(@word)

			WHILE(@index <= @wordLength)
				BEGIN					
					SET @currentChar = SUBSTRING(@word, @index, 1)
					IF(CHARINDEX(@currentChar, @pattern) <= 0)
						BEGIN
							RETURN 0
						END
					SET @index = @index + 1
				END
				RETURN 1
		END
GO

ALTER FUNCTION ufn_PatternSearch(@pattern nvarchar(50))
	RETURNS TABLE
AS
	RETURN(
		SELECT FirstName AS [Result] FROM Employees
			WHERE dbo.ufn_CheckLetters(FirstName, @pattern) = 1 AND FirstName IS NOT NULL
		UNION
		SELECT LastName AS [Result] FROM Employees
			WHERE dbo.ufn_CheckLetters(LastName, @pattern) = 1 AND LastName IS NOT NULL
		UNION
		SELECT MiddleName AS [Result] FROM Employees
			WHERE dbo.ufn_CheckLetters(MiddleName, @pattern) = 1 AND MiddleName IS NOT NULL
		UNION
		SELECT Name AS [Result] FROM Towns
			WHERE dbo.ufn_CheckLetters(Name, @pattern) = 1 AND Name IS NOT NULL
	)

SELECT * FROM dbo.ufn_PatternSearch('oistmiahf')

