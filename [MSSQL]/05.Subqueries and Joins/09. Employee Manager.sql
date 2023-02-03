SELECT e.EmployeeID, e.FirstName, e2.EmployeeID, e2.FirstName AS ManagarName
FROM Employees AS e
    JOIN Employees AS e2 ON e.ManagerID = e2.EmployeeID
WHERE e2.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID