CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
    SELECT
		CONCAT([FirstName], ' ', [LastName])
	FROM [AccountHolders]
END

EXEC dbo.usp_GetHoldersFullName