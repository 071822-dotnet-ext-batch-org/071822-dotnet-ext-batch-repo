SELECT * FROM dbo.Genre;

SELECT * FROM dbo.Employee WHERE Title LIKE '%Manager%';

-- the '%' symbol is a wildcard. it means 'any number of any character(s)'.
-- the '_' symbol is also a wildcard. It means 'any single charcter'.
SELECT FirstName, EmployeeID FROM dbo.Employee WHERE Title LIKE '%Manager'; 

SELECT FirstName, EmployeeID, Title FROM dbo.Employee WHERE Title LIKE 'S%';

SELECT FirstName, EmployeeID, Title FROM dbo.Employee ORDER BY FirstName DESC;

INSERT INTO dbo.Employee (EmployeeId, FirstName, LastName, Title, HireDate, Address) VALUES ((Select MAX(EmployeeID) FROM dbo.Employee)+1,'Mark','Moore','Usurper', GetDate(),'432 Forthritu Ln.');

Select MAX(EmployeeID) FROM dbo.Employee;

UPDATE dbo.Employee SET ReportsTo = (SELECT TOP 1 EmployeeID FROM dbo.Employee WHERE Title = 'Sales Support Agent') 
WHERE FirstName = 'Mark' AND LastName = 'Moore';

DELETE FROM dbo.Employee WHERE FirstName = 'Nancy' AND LastName LIKE 'Edward_';

UPDATE dbo.Employee SET ReportsTo = 1 WHERE ReportsTo = 2; 

SELECT FROM dbo.Employee WHERE FirstName = 'Nancy' AND LastName LIKE 'Edward_';

-- not working
--SELECT * FROM Deleted;

SELECT Concat(FirstName,' ', LastName) AS FullName, CustomerID,Country FROM dbo.Customer WHERE Country != 'USA' ORDER BY Country;
Select * from [dbo].[Customer]
