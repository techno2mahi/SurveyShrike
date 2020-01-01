-- drop table [Response]
-- drop table [FormField]
 --drop table [Survey]

-- Survey
CREATE TABLE  [Survey]  (
     Id  [int] IDENTITY(1,1) NOT NULL,
	 Title  [nvarchar](50) NOT NULL,
     CreatedOn  datetime   NULL,
     CreatedBy  [nvarchar](50)  NULL,
	 ModifiedOn  datetime   NULL,
     ModifiedBy  [nvarchar](50)  NULL,
     IsDeleted  bit NOT NULL DEFAULT 0,
	 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)

GO

--FormField
CREATE TABLE  [FormField]  (
     Id  [int] IDENTITY(1,1) NOT NULL,
     Title  [nvarchar](200) NOT NULL,
     FormTypes  INT NOT NULL,
     FormConfiguration [nvarchar](100) NOT NULL,
     SurveyId  int NULL,
	  CONSTRAINT [PK_FormField] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

ALTER TABLE [dbo].[FormField]  WITH CHECK ADD  CONSTRAINT [FK_FormField_Survey] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Survey] (Id)
GO

ALTER TABLE [dbo].[FormField] CHECK CONSTRAINT [FK_FormField_Survey]
GO



-- Response
CREATE TABLE  [Response]  (
     Id  [int] IDENTITY(1,1) NOT NULL,
     Response  [nvarchar](200) NOT NULL,
     CreatedOn  datetime   NULL, 
     FormFieldId  INTEGER NULL,
	 CONSTRAINT [PK_Response] PRIMARY KEY CLUSTERED 
	 (
		[Id] ASC
	 )
)
GO 
ALTER TABLE [dbo].[Response]  WITH CHECK ADD  CONSTRAINT [FK_Response_FormField] FOREIGN KEY([FormFieldId])
REFERENCES [dbo].[FormField] (Id)
GO

ALTER TABLE [dbo].[Response] CHECK CONSTRAINT [FK_Response_FormField]
GO



