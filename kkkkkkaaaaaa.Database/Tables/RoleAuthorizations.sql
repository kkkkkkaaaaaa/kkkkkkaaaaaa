CREATE TABLE [dbo].[RoleAuthorizations] (
    [RoleID]          BIGINT NOT NULL,
    [AuthorizationID] BIGINT NOT NULL, 
    CONSTRAINT [PK_RoleAuthorizations] PRIMARY KEY ([RoleID], [AuthorizationID])
);

