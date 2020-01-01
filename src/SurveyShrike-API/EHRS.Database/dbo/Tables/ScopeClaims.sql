CREATE TABLE [dbo].[ScopeClaims] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [Name]                   NVARCHAR (200)  NOT NULL,
    [Description]            NVARCHAR (1000) NULL,
    [AlwaysIncludeInIdToken] BIT             NOT NULL,
    [Scope_Id]               INT             NOT NULL,
    CONSTRAINT [PK_dbo.ScopeClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ScopeClaims_dbo.Scopes_Scope_Id] FOREIGN KEY ([Scope_Id]) REFERENCES [dbo].[Scopes] ([Id]) ON DELETE CASCADE
);

