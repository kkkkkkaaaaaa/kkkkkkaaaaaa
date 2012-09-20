CREATE TABLE [dbo].[RoleAuthorizations] (
    [RoleID]          BIGINT NOT NULL,
    [AuthorizationID] BIGINT NOT NULL,
    CONSTRAINT [PK_RoleAuthorizations_1] PRIMARY KEY CLUSTERED ([RoleID] ASC, [AuthorizationID] ASC)
);

