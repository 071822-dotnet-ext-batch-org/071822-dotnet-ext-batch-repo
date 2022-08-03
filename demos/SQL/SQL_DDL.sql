--create the Customers table
CREATE TABLE Customers(
CustomerId INT IDENTITY(1, 1),--IDENTITY() does not ensure uniqueness so you will have to alter the table to add the PK constraint to this column.
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Notes NTEXT NULL
);

--create the Addresses table
CREATE TABLE Addresses(
AddressId INT IDENTITY(1, 1),-- see above
NumberStreet NVARCHAR(50) NOT NULL,
AptSuite NVARCHAR(7) NULL,
City NVARCHAR(85) NOT NULL,
ZipCode CHAR(5) NULL,  -- assume that every country uses numbers that equate to our zip code.
CountryCode SMALLINT NULL check(CountryCode between 0 and 999)-- between is inclusive so we alter this below
);

--create the orders table
CREATE TABLE Orders(
OrderId INT PRIMARY KEY IDENTITY(1, 1),
OrderDate DATETIME DEFAULT(GETDATE()),
OrderTotal DECIMAL(6,2) NOT NULL,
FK_Customer INT FOREIGN KEY REFERENCES Customers(CustomerId) NOT NULL,
FK_Address INT FOREIGN KEY REFERENCES Addresses(AddressId) NOT NULL
);

--create the Customers/Addresses Junction table
CREATE TABLE CustomerAddressJunction(
FK_Customer INT FOREIGN KEY REFERENCES Customers(CustomerId) ,
FK_Address INT FOREIGN KEY REFERENCES Addresses(AddressId)
);

-- add a new constraint to a table column.
ALTER TABLE Addresses 
ADD CONSTRAINT valid_country_code CHECK(CountryCode between 1 and 998);

-- if you don't have a PK in a table, yo can add one later.
ALTER TABLE Addresses 
ADD PRIMARY KEY (AddressId);

ALTER TABLE Customers 
ADD PRIMARY KEY (CustomerId);

ALTER TABLE Orders 
ADD PRIMARY KEY (OrderId);

--delete a record from a table
DELETE FROM Addresses WHERE CountryCode = 0;

--insert into the table
INSERT INTO Addresses (NumberStreet, City, CountryCode) VALUES('111 myStreet Ln.','Burleson',0);

-- drop a specific constraint of a table (when you know it's name).
ALTER TABLE Addresses
DROP Constraint CK__Addresses__Count__5CD6CB2B;

-- get a list of the constraints on a table.
SELECT TABLE_CATALOG, TABLE_NAME,
       CONSTRAINT_TYPE,CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS;
