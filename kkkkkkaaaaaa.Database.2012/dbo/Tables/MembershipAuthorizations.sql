CREATE TABLE [dbo].[MembershipAuthorizations]
(
    [ID] BIGINT NOT NULL, 
	[MembershipID] BIGINT NOT NULL , 
    [AuthorizationID] BIGINT NOT NULL, 
    [Enabled] BIT NOT NULL, 
    CONSTRAINT [PK_MembershipAuthorizations] PRIMARY KEY ([ID]) 
)
