

-- ============================================================
-- CREAR BASE DE DATOS
-- ============================================================

CREATE DATABASE UniversidadDB;
GO

USE UniversidadDB;
GO


-- ============================================================
-- CREAR ESQUEMAS
-- ============================================================

IF NOT EXISTS (
    SELECT 1
    FROM sys.schemas
    WHERE name = 'General'
)
BEGIN
    EXEC('CREATE SCHEMA General');
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.schemas
    WHERE name = 'Academic'
)
BEGIN
    EXEC('CREATE SCHEMA Academic');
END
GO


-- ============================================================
-- TABLA: General.Person
-- ============================================================

CREATE TABLE [General].[Person]
(
    [PersonId] INT IDENTITY(1,1) NOT NULL,

    [Person_FirstName] VARCHAR(100) NOT NULL,

    [Person_LastName] VARCHAR(100) NOT NULL,

    [Person_BirthDate] DATE NULL,

    [Email] VARCHAR(150) NOT NULL,

    [Person_DocumentId] VARCHAR(50) NOT NULL,

    [Person_Addres] VARCHAR(250) NULL,

    [Person_Phone] VARCHAR(50) NULL,

    [Genero] CHAR(1) NULL,

    [Nacionalidad] CHAR(50) NULL,

    [DateCreate] DATETIME NOT NULL
        CONSTRAINT [DF_Person_DateCreate]
        DEFAULT GETDATE(),

    [Act] BIT NOT NULL
        CONSTRAINT [DF_Person_Act]
        DEFAULT 1,

    CONSTRAINT [PK_Person]
        PRIMARY KEY CLUSTERED ([PersonId])
);
GO


-- ============================================================
-- TABLA: Academic.Students
-- ============================================================

CREATE TABLE [Academic].[Students]
(
    [StudentId] INT IDENTITY(1,1) NOT NULL,

    [PersonId] INT NOT NULL,

    [Matricula] VARCHAR(50) NOT NULL,

    [DateCreate] DATETIME NOT NULL
        CONSTRAINT [DF_Students_DateCreate]
        DEFAULT GETDATE(),

    [Act] BIT NOT NULL
        CONSTRAINT [DF_Students_Act]
        DEFAULT 1,

    CONSTRAINT [PK_Students]
        PRIMARY KEY CLUSTERED ([StudentId]),

    CONSTRAINT [FK_Students_Person]
        FOREIGN KEY ([PersonId])
        REFERENCES [General].[Person] ([PersonId])
);
GO
