CREATE TABLE [dbo].[ObjectTypes]
(
	[ID] INT NOT NULL , 
    [Name] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Enabled] BIT NOT NULL, 
    CONSTRAINT [PK_ObjectTypes] PRIMARY KEY ([ID]) 
)
