CREATE TABLE [dbo].[Scopes] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [Enabled]                 BIT             NOT NULL,
    [Name]                    NVARCHAR (200)  NOT NULL,
    [DisplayName]             NVARCHAR (200)  NULL,
    [Description]             NVARCHAR (1000) NULL,
    [Required]                BIT             NOT NULL,
    [Emphasize]               BIT             NOT NULL,
    [Type]                    INT             NOT NULL,
    [IncludeAllClaimsForUser] BIT             NOT NULL,
    [ClaimsRule]              NVARCHAR (200)  NULL,
    [ShowInDiscoveryDocument] BIT             NOT NULL,
    CONSTRAINT [PK_dbo.Scopes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

