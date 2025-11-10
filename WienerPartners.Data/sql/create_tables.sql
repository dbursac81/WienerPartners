
IF DB_ID('WienerDb') IS NULL
BEGIN
    CREATE DATABASE WienerDb;
    PRINT 'Database "WienerDb" created.';
END
ELSE
BEGIN
    PRINT 'Database "WienerDb" already exists.';
END
GO

USE WienerDb;
GO

CREATE TABLE dbo.Partners (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(1000) NULL,
    PartnerNumber NVARCHAR(20) NOT NULL,
    CroatianPIN NVARCHAR(50) NULL,
    PartnerTypeId INT NOT NULL,
    CreatedAtUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CreateByUser NVARCHAR(255) NOT NULL,
    IsForeign BIT NOT NULL,
    ExternalCode NVARCHAR(20) NULL UNIQUE,
    Gender CHAR(1) NOT NULL CHECK (Gender IN ('M','F','N'))
);
GO

CREATE TABLE dbo.Policies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Number NVARCHAR(15) NOT NULL,
    Value DECIMAL(18,2) NOT NULL CHECK (Amount >= 0),
    PartnerId INT NOT NULL,
    CreatedAtUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Policies_Partners FOREIGN KEY (PartnerId) REFERENCES dbo.Partners(Id)
);
GO

INSERT INTO dbo.Partners 
(FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreatedAtUtc, CreateByUser, IsForeign, ExternalCode, Gender)
VALUES
('Ivan', 'Horvat', 'Zagreb, Ilica 10', 'P0000000000000000001', '12345678901', 1, SYSUTCDATETIME(), 'admin@wiener.hr', 0, 'EX001', 'M'),
('Ana', 'Kovač', 'Split, Riva 5', 'P0000000000000000002', '98765432109', 1, SYSUTCDATETIME(), 'admin@wiener.hr', 0, 'EX002', 'F'),
('ACME d.o.o.', '—', 'Osijek, Industrijska 12', 'C0000000000000000001', NULL, 2, SYSUTCDATETIME(), 'admin@wiener.hr', 0, 'EX003', 'N');
GO

INSERT INTO dbo.Policies (Number, Value, PartnerId, CreatedAtUtc)
VALUES
('POLICA0001', 1200.50, 1, SYSUTCDATETIME()),
('POLICA0002', 850.00, 2, SYSUTCDATETIME()),
('POLICA0003', 4500.00, 3, SYSUTCDATETIME());
GO

SELECT * FROM dbo.Partners;
SELECT * FROM dbo.Policies;
GO

