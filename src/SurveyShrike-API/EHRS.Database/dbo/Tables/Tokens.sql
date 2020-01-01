CREATE TABLE [dbo].[Tokens] (
    [Key]       NVARCHAR (128)     NOT NULL,
    [TokenType] SMALLINT           NOT NULL,
    [SubjectId] NVARCHAR (200)     NULL,
    [ClientId]  NVARCHAR (200)     NOT NULL,
    [JsonCode]  NVARCHAR (MAX)     NOT NULL,
    [Expiry]    DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_dbo.Tokens] PRIMARY KEY CLUSTERED ([Key] ASC, [TokenType] ASC)
);

