CREATE PROCEDURE usp_GetTownsStartingWith
    (@string VARCHAR(50))
AS
BEGIN
    SELECT [Name]
    FROM [Towns]
    WHERE SUBSTRING([Name], 1, LEN(@string)) = @string
END

EXEC dbo.usp_GetTownsStartingWith 'b'