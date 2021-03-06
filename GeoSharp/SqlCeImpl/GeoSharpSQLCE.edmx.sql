
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 09/29/2015 16:55:46
-- Generated from EDMX file: D:\DevDocs\GeoSharp\GeoSharp\SqlCeImpl\GeoSharpSQLCE.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    DROP TABLE [ISO3166_2_156];
GO
    DROP TABLE [ISO3166Set];
GO
    DROP TABLE [ISO3166_1_ALPHA_2];
GO
    DROP TABLE [ISO3166_1_ALPHA_3];
GO
    DROP TABLE [ISO3166_1_NUMERIC];
GO
    DROP TABLE [ISO3166_2];
GO
    DROP TABLE [ISO3166_3];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ISO3166_2_156'
CREATE TABLE [ISO3166_2_156] (
    [Id] int  NOT NULL,
    [Province] nvarchar(4000)  NOT NULL,
    [City] nvarchar(4000)  NULL,
    [District] nvarchar(4000)  NULL
);
GO

-- Creating table 'ISO3166Set'
CREATE TABLE [ISO3166Set] (
    [Id] int  NOT NULL,
    [Name] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'ISO3166_1_ALPHA_2'
CREATE TABLE [ISO3166_1_ALPHA_2] (
    [Code] nvarchar(4)  NOT NULL,
    [CountryName] nvarchar(4000)  NOT NULL,
    [Year] smallint  NOT NULL,
    [ccTLD] nvarchar(16)  NOT NULL,
    [ISO3166_2] nvarchar(16)  NOT NULL,
    [Notes] nvarchar(4000)  NULL
);
GO

-- Creating table 'ISO3166_1_ALPHA_3'
CREATE TABLE [ISO3166_1_ALPHA_3] (
    [Code] nvarchar(8)  NOT NULL,
    [CountryName] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'ISO3166_1_NUMERIC'
CREATE TABLE [ISO3166_1_NUMERIC] (
    [Id] nvarchar(4)  NOT NULL,
    [CountryName] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'ISO3166_2'
CREATE TABLE [ISO3166_2] (
    [Entry] nvarchar(4000)  NOT NULL,
    [CountryName] nvarchar(4000)  NOT NULL,
    [SubdivisionsAssignedCodes] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'ISO3166_3'
CREATE TABLE [ISO3166_3] (
    [FormerCountryName] int IDENTITY(1,1) NOT NULL,
    [FormerCodes] nvarchar(4000)  NOT NULL,
    [PeriodOfValidity] nvarchar(4000)  NOT NULL,
    [ISO3166_3Code] nvarchar(4000)  NOT NULL,
    [NewCountryName] nvarchar(4000)  NOT NULL,
    [NewCountryCode] nvarchar(4000)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ISO3166_2_156'
ALTER TABLE [ISO3166_2_156]
ADD CONSTRAINT [PK_ISO3166_2_156]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'ISO3166Set'
ALTER TABLE [ISO3166Set]
ADD CONSTRAINT [PK_ISO3166Set]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Code] in table 'ISO3166_1_ALPHA_2'
ALTER TABLE [ISO3166_1_ALPHA_2]
ADD CONSTRAINT [PK_ISO3166_1_ALPHA_2]
    PRIMARY KEY ([Code] );
GO

-- Creating primary key on [Code] in table 'ISO3166_1_ALPHA_3'
ALTER TABLE [ISO3166_1_ALPHA_3]
ADD CONSTRAINT [PK_ISO3166_1_ALPHA_3]
    PRIMARY KEY ([Code] );
GO

-- Creating primary key on [Id] in table 'ISO3166_1_NUMERIC'
ALTER TABLE [ISO3166_1_NUMERIC]
ADD CONSTRAINT [PK_ISO3166_1_NUMERIC]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Entry] in table 'ISO3166_2'
ALTER TABLE [ISO3166_2]
ADD CONSTRAINT [PK_ISO3166_2]
    PRIMARY KEY ([Entry] );
GO

-- Creating primary key on [FormerCountryName] in table 'ISO3166_3'
ALTER TABLE [ISO3166_3]
ADD CONSTRAINT [PK_ISO3166_3]
    PRIMARY KEY ([FormerCountryName] );
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------