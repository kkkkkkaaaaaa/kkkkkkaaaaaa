CREATE TABLE [dbo].[UserRoles] (
    [UserID] BIGINT NOT NULL,
    [RoleID] BIGINT NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([UserID] ASC, [RoleID] ASC)
);

