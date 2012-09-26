CREATE TABLE [dbo].[MembershipAuthorizations]
(
	[MembershipID] BIGINT NOT NULL , 
    [AuthorizationID] BIGINT NOT NULL, 
    PRIMARY KEY ([MembershipID], [AuthorizationID])
)
