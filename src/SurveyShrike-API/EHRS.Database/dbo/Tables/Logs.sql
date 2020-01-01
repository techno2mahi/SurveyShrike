CREATE TABLE [dbo].[Logs] (
    [ErrorLogId]     INT            IDENTITY (1, 1) NOT NULL,
    [Severity]       NVARCHAR (50)  NOT NULL,
    [Message]        NVARCHAR (MAX) NULL,
    [StackTrace]     NVARCHAR (MAX) NULL,
    [InnerException] NVARCHAR (MAX) NULL,
    [Source]         NVARCHAR (MAX) NULL,
    [LogDate]        DATETIME       NOT NULL,
    [UserId]         INT            NOT NULL,
    [HTTPStatusCode] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Logs] PRIMARY KEY CLUSTERED ([ErrorLogId] ASC)
);

