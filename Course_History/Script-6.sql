-- DROP SCHEMA dbo;
CREATE DATABASE COURSE_HISTORY
CREATE SCHEMA dbo;
-- Test.dbo.Cart definition

-- Drop table

-- DROP TABLE Test.dbo.Cart;

-- Test.dbo.Category definition

-- Drop table

-- DROP TABLE Test.dbo.Category;

CREATE TABLE Category (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Status int DEFAULT 1 NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY (Id)
);
INSERT INTO Test.dbo.Category (Name,Status) VALUES
	 (N'Cao Ly sử',1),
	 (N'Chiến Quốc sách',1),
	 (N'Cựu Ngũ Đại sử',1);


-- Test.dbo.Product definition

-- Drop table

-- DROP TABLE Test.dbo.Product;

CREATE TABLE Product (
	Id int IDENTITY(1,1) NOT NULL,
	CategoryId int NOT NULL,
	Name nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Status int NOT NULL,
	Price float NOT NULL,
	[Image] nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Quantity int NOT NULL,
	CONSTRAINT PK_Product PRIMARY KEY (Id)
);


INSERT INTO Product (CategoryId,Name,Status,Price,[Image],Quantity) VALUES
	 (1,N'Đại Việt Sư Ký Toàn Thư',1,500000.0,N'Dai-Viet-Su-Ky-Toan-Thu1.bmp',1000),
	 (2,N'Lý Nam Đế',1,600000.0,N'ly-nam-de.jpg',2000);



CREATE TABLE OrderDetails (
	Id int IDENTITY(1,1) NOT NULL,
	OrderCode nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UserName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ProductId int NOT NULL,
	Price float NOT NULL,
	Quantity int NOT NULL,
	CONSTRAINT PK_OrderDetails PRIMARY KEY (Id)
);


-- Test.dbo.Orders definition

-- Drop table

-- DROP TABLE Test.dbo.Orders;

CREATE TABLE Orders (
	Id int IDENTITY(1,1) NOT NULL,
	OrderCode nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	UserName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CreatedDate datetime2 NOT NULL,
	Status int NOT NULL,
	TotalMoney float NULL,
	CONSTRAINT PK_Orders PRIMARY KEY (Id)
);



