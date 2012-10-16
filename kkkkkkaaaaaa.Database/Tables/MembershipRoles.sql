CREATE TABLE [dbo].[MembershipRoles]
(
	[MembershipID] BIGINT NOT NULL , 
    [RoleID] BIGINT NOT NULL, 
    CONSTRAINT [PK_MembershipRoles] PRIMARY KEY ([MembershipID], [RoleID]) 
)
