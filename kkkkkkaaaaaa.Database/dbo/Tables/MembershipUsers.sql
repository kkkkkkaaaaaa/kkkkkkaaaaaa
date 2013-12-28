CREATE TABLE [dbo].[MembershipUsers]
(
    [MembershipID] BIGINT NOT NULL, 
    [UserID] BIGINT NOT NULL, 
    CONSTRAINT [PK_MembershipUsers] PRIMARY KEY ([MembershipID], [UserID]), 
    CONSTRAINT [FK_MembershipUsers_Memberships] FOREIGN KEY ([MembershipID]) REFERENCES [Memberships]([ID])
		ON DELETE CASCADE, 
    CONSTRAINT [FK_MembershipUsers_Users] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID])
)
