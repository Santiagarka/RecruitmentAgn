CREATE TABLE [dbo].[Candidates] (
    [Id]          INT             NOT NULL,
    [FIO]         NVARCHAR (MAX)  NOT NULL,
    [DateOfBirth] DATETIME2 (0)   NOT NULL,
    [Experience]  INT             NOT NULL,
    [FotoURL]     NVARCHAR (MAX)  NULL,
    [Salary]      DECIMAL (10, 2) NOT NULL,
    [CreatorId]   INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

