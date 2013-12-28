CREATE TABLE [dbo].[MembershipRoles]
(
	[MembershipID] BIGINT NOT NULL , 
    [RoleID] BIGINT NOT NULL, 
    CONSTRAINT [PK_MembershipRoles] PRIMARY KEY ([MembershipID], [RoleID]), 
    CONSTRAINT [FK_MembershipRoles_Memberships] FOREIGN KEY ([MembershipID]) REFERENCES [Memberships]([ID]) 
)
