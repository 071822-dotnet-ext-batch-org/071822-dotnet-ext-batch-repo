-- 1) create a table to hold the pending data.
CREATE TABLE Customer_Audit(
ChangeId INT PRIMARY KEY IDENTITY(1,1),
CustomerID INT NOT NULL,
FirstName NVARCHAR(30),
LastName NVARCHAR(30),
UpdatedAt DATETIME DEFAULT(GETDATE()),
OperationType CHAR(3),
CONSTRAINT Opp_Type_Ins_or_Del check(OperationType = 'DEL' OR OperationType = 'INS')
);


-- 2) Create the AFTER trigger 
CREATE TRIGGER CustomerAdded ON Customers
INSTEAD OF INSERT, DELETE
AS
	INSERT INTO Customer_Audit (CustomerID,FirstName,LastName,OperationType)
		SELECT CustomerID,FirstName,LastName, 'INS'
		FROM inserted -- need to verify
UNION
	SELECT CustomerID,FirstName,LastName, 'DEL'
	FROM deleted -- need to verify



-- insert
INSERT INTO Customers (FirstName, LastName)
VALUES ('John', 'Gacy');