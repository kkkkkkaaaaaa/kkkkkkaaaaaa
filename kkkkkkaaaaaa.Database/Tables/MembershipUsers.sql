CREATE TABLE [dbo].[MembershipUsers]
(
    [MembershipID] BIGINT NOT NULL, 
    [UserID] BIGINT NOT NULL, 
    CONSTRAINT [PK_MembershipUsers] PRIMARY KEY ([MembershipID], [UserID]) 
)
