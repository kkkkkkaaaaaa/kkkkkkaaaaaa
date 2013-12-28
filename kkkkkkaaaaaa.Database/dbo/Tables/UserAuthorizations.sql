CREATE TABLE [dbo].[UserAuthorizations] (
    [UserID]          BIGINT NOT NULL,
    [AuthorizationID] BIGINT NOT NULL, 
    CONSTRAINT [PK_UserAuthorizations] PRIMARY KEY ([UserID], [AuthorizationID])
);

