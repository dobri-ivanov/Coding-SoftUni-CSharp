CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(50)
BEGIN
    RETURN
    CASE
    WHEN @salary < 30000 THEN 'Low'
    WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
    WHEN @salary > 50000 THEN 'High'
    END
END

