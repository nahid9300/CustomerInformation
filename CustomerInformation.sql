CREATE DATABASE CustomerInformation
USE CustomerInformation

CREATE TABLE Customers(
id INT IDENTITY(1,1) PRIMARY KEY,
Code VARCHAR(50),
Name VARCHAR(50),
Address VARCHAR(50),
Contact VARCHAR(50),
DistrictId int
)
 SELECT*FROM Customers

 DROP TABLE Customers

 CREATE TABLE DistrictInfo(
 id INT IDENTITY(1,1) PRIMARY KEY,
 District VARCHAR(50)
 )

 SELECT*FROM DistrictInfo

 INSERT INTO DistrictInfo VALUES('Barishal')
 INSERT INTO DistrictInfo VALUES('Comilla')
 INSERT INTO DistrictInfo VALUES('Noakhali')
 INSERT INTO DistrictInfo VALUES('Dhaka')

 CREATE VIEW CustomerDetailsView
 AS
 SELECT Code,Name,Address,Contact, DistrictId FROM Customers AS c
 LEFT JOIN DistrictInfo AS d ON d.id=c.DistrictID 
 Select*from CustomerDetailsView

 DELETE FROM Customers