SELECT result.DepositGroup, result.TotalSum
FROM
( 
    SELECT
        DepositGroup,
        SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
    WHERE MagicWandCreator = 'Ollivander family'
    GROUP BY DepositGroup
) AS result
WHERE result.TotalSum < 150000
ORDER BY TotalSum DESC