﻿CREATE TABLE [dbo].[MembershipAuthorizations]
(
	[MembershipID] BIGINT NOT NULL , 
    [AuthorizationID] BIGINT NOT NULL, 
    CONSTRAINT [PK_MembershipAuthorizations] PRIMARY KEY ([MembershipID], [AuthorizationID]), 
    CONSTRAINT [FK_MembershipAuthorizations_Membership] FOREIGN KEY ([MembershipID]) REFERENCES [Memberships]([ID]) 
)
