CREATE TABLE [dbo].[UserHistories]
(
    [UserID] BIGINT NOT NULL, 
    [Revision] INT NOT NULL, 
    [FamilyName] NVARCHAR(1024) NOT NULL, 
    [GivenName] NVARCHAR(1024) NOT NULL, 
    [AdditionalName] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Enabled] BIT NOT NULL, 
    [CreatedOn] DATETIME2 NOT NULL, 
    CONSTRAINT [PK_UserHistories] PRIMARY KEY ([UserID], [Revision]) 
)
