-- simple LEFT JOIN
SELECT FirstName, LastName As "Dude's Last Name", OrderTotal
FROM Customers C LEFT JOIN [dbo].[Orders]
ON CustomerId = FK_Customer;

-- simple RIGHT JOIN (Customers <- Orders <- Addresses)
SELECT FirstName, LastName As "Dude's Last Name", OrderTotal
FROM Customers C RIGHT JOIN [dbo].[Orders]
ON CustomerId = FK_Customer;


-- multi-table LEFT JOIN  (Customers <- Junction <- Addresses)
SELECT FirstName, LastName As "Dude's Last Name", NumberStreet, OrderTotal, City, ZipCode
FROM Customers C 
LEFT JOIN [dbo].[Orders] O ON CustomerId = FK_Customer
LEFT JOIN Addresses A ON O.FK_Address = A.AddressId;

--right join (Customers -> Junction -> Addresses)
SELECT FirstName, LastName As "The Dude", NumberStreet, City, ZipCode
FROM Customers C
RIGHT JOIN [dbo].[CustomerAddressJunction] J ON C.CustomerId = J.FK_Customer
RIGHT JOIN [dbo].[Addresses] A ON J.FK_Address = A.AddressId;
