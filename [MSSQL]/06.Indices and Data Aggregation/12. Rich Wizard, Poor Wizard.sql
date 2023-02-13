SELECT SUM(result.Difference) AS SumDifference
FROM
    (
    SELECT
        w1.FirstName AS Host,
        w1.DepositAmount AS HostDeposit,
        w2.FirstName AS Guest,
        w2.DepositAmount AS GuestDeposit,
        w2.DepositAmount - w1.DepositAmount AS Difference
    FROM WizzardDeposits AS w1
        JOIN WizzardDeposits AS w2 ON w1.id = w2.Id + 1
) AS result