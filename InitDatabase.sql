USE master;
GO

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Upd8')
BEGIN 
	CREATE DATABASE Upd8;
END

GO

USE Upd8;
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='Customer' and xtype='U')
BEGIN
    CREATE TABLE Customer (
        [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
        [Name] NVARCHAR(100),
        [Document] NVARCHAR(14),
        [BirthDate] DATETIME2,
        [Gender] NVARCHAR(7),
        [StreetName] NVARCHAR(120),
        [City] NVARCHAR(60),
        [State] NVARCHAR(2),
        [Country] NVARCHAR(20),
        [CreatedAt] DATETIME2,
        [UpdatedAt] DATETIME2,
        [Active] BIT NOT NULL DEFAULT 1,
        [Deleted] BIT NOT NULL DEFAULT 0
    )
END
