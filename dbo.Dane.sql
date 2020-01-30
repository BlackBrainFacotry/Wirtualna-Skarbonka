CREATE TABLE [dbo].[Dane] (
    [Id]       INT        NOT NULL,
    [tytul]    NVARCHAR(50) NULL,
    [kwota]    DECIMAL(18, 2) NULL,
    [opis]     NVARCHAR(MAX) NULL,
    [dod_kwot] DECIMAL(18, 2) NULL,
    [data]     DATETIME   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

