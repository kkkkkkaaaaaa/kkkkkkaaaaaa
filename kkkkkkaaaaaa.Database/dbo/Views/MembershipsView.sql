CREATE VIEW
	[dbo].[MembershipsView]
AS
	SELECT
		ID, Name, /*[Password],*/ [Enabled], CreatedOn, UpdatedOn
	FROM
		dbo.Memberships
