USE SuperheroesUniverse
GO

--- 1. List all superheroes in Earth

SELECT s.Id, s.Name FROM Superheroes s
	INNER JOIN PlanetSuperheroes ps
	ON s.Id = ps.Superhero_Id
	INNER JOIN Planets p
	ON p.Id = ps.Planet_Id
	WHERE p.Name = 'Earth'
	ORDER BY s.Id

--- 2. List all superheroes with their powers and powerTypes

SELECT s.Name AS [Superhero], p.Name + ' ' + '(' + pt.Name + ')' AS [Power] FROM Superheroes s
	INNER JOIN PowerSuperheroes psh
	ON psh.Superhero_Id = s.Id
	INNER JOIN Powers p
	ON psh.Power_Id = p.Id
	INNER JOIN PowerTypes pt
	ON p.PowerTypeId = pt.Id
	ORDER BY s.Name

--- 3. List the top 5 planets, sorted by count of superheroes with alignment 'Good', then by Planet Name

SELECT TOP 5 p.Name AS [Planet],
		COUNT(case a.Name when 'Good' then 1 else null end) AS [Good heroes] FROM Superheroes s
			INNER JOIN Alignments a
			ON s.Alignment_Id = a.Id
			INNER JOIN PlanetSuperheroes psh
			ON psh.Superhero_Id = s.Id
			INNER JOIN Planets p
			ON psh.Planet_Id = p.Id
			GROUP BY p.Name
			ORDER BY COUNT(case a.Id when 1 then 1 else null end) DESC, p.Name
GO
--- 4. Create a stored procedure to edit superheroes Bio, by provided Superhero's Id and the new bio

CREATE OR ALTER PROC usp_UpdateSuperheroBio @superHeroId int, @newBio ntext
AS
	BEGIN	
		UPDATE Superheroes
			SET Bio = @newBio
			WHERE Id = @superHeroId
	END

GO

EXEC usp_UpdateSuperheroBio 1, 'hahahahaha'
GO
--- 5. Create a stored prodecure, that gives full information about a superhero, by provided Superhero's Id

CREATE OR ALTER PROC usp_GetSuperheroInfo @superHeroId int
AS
	BEGIN
		SELECT s.Id, s.Name, s.SecretIdentity, s.Bio, a.Name AS [Alignment], p.Name AS [Planet], pow.Name AS [Power] FROM Superheroes s
			LEFT JOIN Alignments a
			ON s.Alignment_Id = a.Id
			LEFT JOIN PlanetSuperheroes psh
			ON psh.Superhero_Id = s.Id
			LEFT JOIN Planets p
			ON psh.Planet_Id = p.Id
			LEFT JOIN PowerSuperheroes powersh
			ON powersh.Superhero_Id = s.Id
			LEFT JOIN Powers pow
			ON powersh.Power_Id = pow.Id
			WHERE s.Id = @superHeroId
	END
GO

EXEC usp_GetSuperheroInfo 16
GO
--- 6. Create a stored procedure that prints the number of heroes with Good, Evil and Neutral alignment for each Planet

CREATE OR ALTER PROC usp_GetPlanetsWithHeroesCount
AS
	BEGIN
		
		SELECT p.Name AS [Planet],
		COUNT(case a.Name when 'Good' then 1 else null end) AS [Good heroes],
		COUNT(case a.Name when 'Neutral' then 1 else null end) AS [Neutral heroes],
		COUNT(case a.Name when 'Evil' then 1 else null end) AS [Evil heroes] FROM Superheroes s
			INNER JOIN Alignments a
			ON s.Alignment_Id = a.Id
			INNER JOIN PlanetSuperheroes psh
			ON psh.Superhero_Id = s.Id
			INNER JOIN Planets p
			ON psh.Planet_Id = p.Id
			GROUP BY p.Name
			ORDER BY COUNT(case a.Id when 1 then 1 else null end) DESC

	END
GO

EXEC usp_GetPlanetsWithHeroesCount
GO

--- 7. Create a stored procedure for creating a Superhero, with provided name, secret identity, bio, alignment, a planet and 3 powers (with their types)

CREATE OR ALTER PROC usp_CreatePowerWithPowerType @powerName nvarchar(40), @powerType nvarchar(40), @newPowerId int OUTPUT
AS
	BEGIN

		DECLARE @newTypeId int

		IF(EXISTS (SELECT Name FROM PowerTypes WHERE Name = @powerType))
			BEGIN
				
				SET @newTypeId = (SELECT Id FROM PowerTypes WHERE Name = @powerType)

			END
		ELSE
			BEGIN
				
				INSERT INTO PowerTypes (Name) VALUES (@powerType)

				SET @newTypeId = (SELECT Id FROM PowerTypes WHERE Name = @powerType)
			END

			--- power check

		IF(EXISTS (SELECT Name FROM Powers WHERE Name = @powerName))
			BEGIN
				
				SET @newPowerId = (SELECT Id FROM Powers WHERE Name = @powerName)

			END
		ELSE
			BEGIN
				
				INSERT INTO Powers (Name, PowerTypeId) VALUES (@powerName, @newTypeId)

				SET @newPowerId = (SELECT Id FROM Powers WHERE Name = @powerName)
			END

		

	END

GO

CREATE OR ALTER PROC usp_CreateSuperHero
	@name nvarchar(40),
	@secretIdentity nvarchar(40),
	@bio ntext,
	@alignment nvarchar(40),
	@planet nvarchar(40),
	@powerOneName nvarchar(40), @powerOneType nvarchar(40),
	@powerTwoName nvarchar(40), @powerTwoType nvarchar(40),
	@powerThreeName nvarchar(40), @powerThreeType nvarchar(40)
AS
	BEGIN
		DECLARE @alignmentIdInsert int
		DECLARE @planetIdInsert int
		DECLARE @newHeroId int

		--- create alignment

		IF((SELECT Name FROM Alignments WHERE Name = @alignment) IS NULL)
			BEGIN
				
				INSERT INTO Alignments (Name) VALUES (@alignment)
				SET @alignmentIdInsert = (SELECT Id FROM Alignments WHERE Name = @alignment)

			END
		ELSE
			BEGIN
				SET @alignmentIdInsert = (SELECT Id FROM Alignments WHERE Name = @alignment)
			END

		--- create super hero

		INSERT INTO Superheroes (Name, SecretIdentity, Alignment_Id, Bio) VALUES (@name, @secretIdentity, @alignmentIdInsert, @bio)

		SET @newHeroId = (SELECT Id FROM Superheroes WHERE Name = @name)

		---- create planet

		IF((SELECT Name FROM Planets WHERE Name = @planet) IS NULL)
			BEGIN
				
				INSERT INTO Planets(Name) VALUES (@planet)
				SET @planetIdInsert = (SELECT Id FROM Planets WHERE Name = @planet)

			END
		ELSE
			BEGIN
				SET @planetIdInsert = (SELECT Id FROM Planets WHERE Name = @planet)
			END
		
		---- link planet ID to hero ID in psh

		INSERT INTO PlanetSuperheroes (Planet_Id, Superhero_Id) VALUES (@planetIdInsert, @newHeroId)

		--- create powers

		DECLARE @powerIDInsertOne int
		EXEC usp_CreatePowerWithPowerType @powerOneName, @powerOneType, @powerIDInsertOne OUTPUT
		
		DECLARE @powerIDInsertTwo int
		EXEC usp_CreatePowerWithPowerType @powerTwoName, @powerTwoType, @powerIDInsertTwo OUTPUT

		DECLARE @powerIDInsertThree int
		EXEC usp_CreatePowerWithPowerType @powerThreeName, @powerThreeType, @powerIDInsertThree OUTPUT

		--- link powers in powsh

		INSERT INTO PowerSuperheroes (Power_Id, Superhero_Id) VALUES (@powerIDInsertOne, @newHeroId)
		INSERT INTO PowerSuperheroes (Power_Id, Superhero_Id) VALUES (@powerIDInsertTwo, @newHeroId)
		INSERT INTO PowerSuperheroes (Power_Id, Superhero_Id) VALUES (@powerIDInsertThree, @newHeroId)

	END
GO

--- inserts new values
EXEC usp_CreateSuperHero 'test hero', 'test identity', 'test bio', 'minion', 'Aior', 'powone', 'typeone', 'powtwo', 'typetwo', 'powthree', 'typethree'

--- reuses values from DB
EXEC usp_CreateSuperHero 'test 2 hero', 'test 2 identity', 'test 2 bio', 'minion', 'Aior', 'powone', 'typeone', 'powtwo', 'typetwo', 'powthree', 'typethree'
GO
--- 8. Create a stored procedure that prints the number of powers by alignment of their superheroes

CREATE OR ALTER PROC usp_PowersUsageByAlignment
AS
	BEGIN
		SELECT a.Name AS [Alignment], COUNT(p.Name) AS [Powers Count] FROM Alignments a
			INNER JOIN Superheroes s
			ON s.Alignment_Id = a.Id
			INNER JOIN PowerSuperheroes psh
			ON psh.Superhero_Id = s.Id
			INNER JOIN Powers p
			ON psh.Power_Id = p.Id
			GROUP BY a.Name
			ORDER BY COUNT(p.Name) DESC
	END
GO

EXEC usp_PowersUsageByAlignment
GO