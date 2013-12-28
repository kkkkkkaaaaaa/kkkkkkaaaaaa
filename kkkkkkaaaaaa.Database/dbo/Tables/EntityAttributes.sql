CREATE TABLE [dbo].[EntityAttributes]
(
    [EntityID] INT NOT NULL, 
	[AttributeID] INT NOT NULL , 
    [AttributeName] NVARCHAR(64) NULL, 
    [AttributeValue] NVARCHAR(MAX) NULL, 
    PRIMARY KEY ([EntityID], [AttributeID]), 
    CONSTRAINT [FK_EntityAttributes_Entities] FOREIGN KEY ([EntityID]) REFERENCES [Entities]([EntityID]), 
    CONSTRAINT [CK_EntityAttributes_ID] CHECK (0 < [AttributeID]) 
)
