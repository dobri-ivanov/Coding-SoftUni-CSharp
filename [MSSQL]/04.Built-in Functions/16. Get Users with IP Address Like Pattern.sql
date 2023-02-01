SELECT UserName AS [Username], IpAddress AS [IP Adress]
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username