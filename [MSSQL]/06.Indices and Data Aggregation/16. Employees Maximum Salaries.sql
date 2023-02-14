SELECT result.DepartmentID ,result.MaxSalary
FROM
(
    SELECT DepartmentID, MAX(Salary) AS MaxSalary
    FROM Employees
    GROUP BY DepartmentID
) AS result
WHERE result.MaxSalary NOT BETWEEN 30000 AND 70000