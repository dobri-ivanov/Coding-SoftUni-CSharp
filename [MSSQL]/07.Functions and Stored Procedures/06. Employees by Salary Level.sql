CREATE PROCEDURE usp_EmployeesBySalaryLevel
    (@level VARCHAR(50))
AS
BEGIN
    SELECT FirstName, LastName
    FROM Employees
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @level
END