
    DROP TABLE [GeoInfoSet];
GO

CREATE TABLE [GeoInfoSet] (
    [Id] int  NOT NULL,
    [Province] nvarchar(4000)  NOT NULL,
    [City] nvarchar(4000)  NULL,
    [District] nvarchar(4000)  NULL
);
GO

ALTER TABLE [GeoInfoSet]
ADD CONSTRAINT [PK_GeoInfoSet]
    PRIMARY KEY ([Id] );
GO