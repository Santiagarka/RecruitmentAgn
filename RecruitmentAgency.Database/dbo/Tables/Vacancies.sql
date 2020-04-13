CREATE TABLE [dbo].[Vacancies] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX)  NOT NULL,
    [Description]  NVARCHAR (MAX)  NOT NULL,
    [Term]         DATETIME2 (0)   NOT NULL,
    [Company]      NVARCHAR (MAX)  NOT NULL,
    [Requirements] NVARCHAR (MAX)  NOT NULL,
    [Salary]       DECIMAL (10, 2) NULL,
    [CreatorId]    INT             NOT NULL,
    [IsActive]     BIT             CONSTRAINT [DF__Vacancies__IsAct__36B12243] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__Vacancie__3214EC07E5969E00] PRIMARY KEY CLUSTERED ([Id] ASC)
);

