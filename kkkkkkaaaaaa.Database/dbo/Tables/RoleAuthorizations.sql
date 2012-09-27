CREATE TABLE [dbo].[RoleAuthorizations] (
    [ID] BIGINT NOT NULL, 
    [RoleID]          BIGINT NOT NULL,
    [AuthorizationID] BIGINT NOT NULL,
    [Enabled] BIT NOT NULL, 
    CONSTRAINT [PK_RoleAuthorizations_1] PRIMARY KEY CLUSTERED ([ID])
);

