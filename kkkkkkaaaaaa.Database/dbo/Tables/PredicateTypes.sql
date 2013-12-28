CREATE TABLE [dbo].[PredicateTypes]
(
	[ID] INT NOT NULL , 
    [Name] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Enabled] BIT NOT NULL, 
    CONSTRAINT [PK_PredicateTypes] PRIMARY KEY ([ID])
)
