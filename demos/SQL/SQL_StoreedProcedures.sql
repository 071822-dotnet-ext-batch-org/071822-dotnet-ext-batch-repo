
-- stored procedure
CREATE PROCEDURE GetFirstCustomerAsc
AS
	SELECT TOP 1 FirstName 
	FROM Customers 
	ORDER BY FirstName ASC;

EXEC GetFirstCustomerAsc;


-- procedure to get how many addresses there are.
CREATE PROCEDURE GetNumAddresses1 (@FirstNamee NVARCHAR(30), @NumAddys INT OUTPUT)
AS
	SELECT @NumAddys = (SELECT Count(*) FROM Addresses);
	SELECT FirstName FROM Customers WHERE FirstName = @FirstNamee;

-- declare some scalar(single value) variable
DECLARE @myVar INT;
DECLARE @LastNameDesc NVARCHAR(30);

--set the value of the scalar variable
SET @LastNameDesc = (SELECT TOP 1 FirstName FROM Customers ORDER BY FirstName DESC)
--execute the procedure
EXEC GetNumAddresses1 @LastNameDesc, @myVar OUTPUT;

-- print the value of the scalar variable to the screen.
SELECT @myVar;