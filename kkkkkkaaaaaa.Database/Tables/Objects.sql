CREATE TABLE [dbo].[Objects]
(
	[ID] BIGINT NOT NULL PRIMARY KEY, 
    [TypeID] INT NOT NULL, 
    [Name] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Enabled] BIT NOT NULL, 
    [CreatedOn] DATETIME2 NOT NULL, 
    [UpdatedOn] DATETIME2 NOT NULL 
)
