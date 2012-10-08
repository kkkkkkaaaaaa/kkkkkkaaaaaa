CREATE VIEW
	MembershipView
AS
	SELECT
		ID, Name, [Password], [Enabled]
	FROM
		dbo.Memberships