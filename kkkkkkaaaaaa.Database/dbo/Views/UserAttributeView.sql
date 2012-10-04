CREATE VIEW UserAttributeView AS

	SELECT
		ITM.ID					AS ItemID
		, ITM.Name				AS ItemName
		, ITM.[Description]
		, ITM.[Enabled]
		, ATT.UserID
		, ATT.Value
	FROM
		UserAttributeItems AS ITM
			INNER JOIN UserAttributes AS ATT ON ITM.ID = ATT.ItemID
