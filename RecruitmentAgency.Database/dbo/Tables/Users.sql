CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Login]    NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [RoleId]   INT            NULL,
    CONSTRAINT [PK__Users__3214EC072C1F75CA] PRIMARY KEY CLUSTERED ([Id] ASC)
);



