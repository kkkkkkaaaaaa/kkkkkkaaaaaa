CREATE TABLE [dbo].[UserHistoryAttributes]
(
	[UserID] BIGINT NOT NULL , 
    [Revision] INT NOT NULL, 
    [ItemID] INT NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_UserHistoryAttributes] PRIMARY KEY ([UserID], [Revision], [ItemID]) 
)
