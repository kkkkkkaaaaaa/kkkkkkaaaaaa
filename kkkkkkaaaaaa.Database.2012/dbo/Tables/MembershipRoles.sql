CREATE TABLE [dbo].[MembershipRoles]
(
    [ID] BIGINT NOT NULL, 
	[MembershipID] BIGINT NOT NULL , 
    [RoleID] BIGINT NOT NULL, 
    [Enabled] BIT NOT NULL, 
    CONSTRAINT [PK_MembershipRoles] PRIMARY KEY ([ID]) 
)
