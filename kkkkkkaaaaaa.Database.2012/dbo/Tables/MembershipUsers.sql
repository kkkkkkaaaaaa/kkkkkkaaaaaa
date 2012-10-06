CREATE TABLE [dbo].[MembershipUsers]
(
	[ID] BIGINT NOT NULL , 
    [MembershipID] BIGINT NOT NULL, 
    [UserID] BIGINT NOT NULL, 
    [Enabled] BIT NOT NULL, 
    CONSTRAINT [PK_MembershipUsers] PRIMARY KEY ([ID]) 
)
