CREATE TABLE [dbo].[Entities]
(
	[EntityID] INT NOT NULL IDENTITY(1, 1), 
    [EntityName] NVARCHAR(64) NULL, 
    CONSTRAINT [PK_Entities] PRIMARY KEY ([EntityID]), 
    CONSTRAINT [CK_Entities_ID] CHECK (0 < [EntityID]) 
)
