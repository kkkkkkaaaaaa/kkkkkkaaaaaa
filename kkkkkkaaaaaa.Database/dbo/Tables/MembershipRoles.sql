CREATE TABLE [dbo].[MembershipRoles]
(
	[MembershipID] BIGINT NOT NULL , 
    [RoleID] BIGINT NOT NULL, 
    PRIMARY KEY ([MembershipID], [RoleID])
)
