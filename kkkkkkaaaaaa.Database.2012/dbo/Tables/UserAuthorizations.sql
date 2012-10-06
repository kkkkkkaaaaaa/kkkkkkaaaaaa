CREATE TABLE [dbo].[UserAuthorizations] (
    [UserID]          BIGINT NOT NULL,
    [AuthorizationID] BIGINT NOT NULL,
    CONSTRAINT [PK_UserAuthorizations_1] PRIMARY KEY CLUSTERED ([UserID] ASC, [AuthorizationID] ASC)
);

