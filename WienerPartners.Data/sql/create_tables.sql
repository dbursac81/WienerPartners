-- Run this script on your WienerDB database to create required tables.

CREATE TABLE Partners (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(1000) NULL,
    PartnerNumber NVARCHAR(20) NOT NULL,
    CroatianPIN NVARCHAR(50) NULL,
    PartnerTypeId INT NOT NULL,
    CreatedAtUtc DATETIME2 NOT NULL,
    CreateByUser NVARCHAR(255) NOT NULL,
    IsForeign BIT NOT NULL,
    ExternalCode NVARCHAR(20) NULL UNIQUE,
    Gender CHAR(1) NOT NULL
);

CREATE TABLE Policies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PolicyNumber NVARCHAR(15) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    PartnerId INT NOT NULL FOREIGN KEY REFERENCES Partners(Id),
    CreatedAtUtc DATETIME2 NOT NULL
);
