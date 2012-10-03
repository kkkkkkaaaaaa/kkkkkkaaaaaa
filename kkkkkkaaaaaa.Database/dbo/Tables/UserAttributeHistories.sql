CREATE TABLE [dbo].[UserAttributeHistories]
(
	[UserID] BIGINT NOT NULL , 
    [ItemID] INT NOT NULL, 
    [Revision] INT NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL, 
    PRIMARY KEY ([Revision], [ItemID], [UserID])
)
