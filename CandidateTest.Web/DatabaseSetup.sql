IF DB_ID(N'CandidateTestDb') IS NULL
BEGIN
    CREATE DATABASE CandidateTestDb;
END
GO

USE CandidateTestDb;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        FirstName NVARCHAR(100) NOT NULL,
        LastName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(150) NOT NULL,
        DateOfBirth DATE NULL,
        CreatedAt DATETIMEOFFSET NOT NULL
    );

    CREATE UNIQUE INDEX IX_Users_Email ON dbo.Users (Email);
END
GO
