DECLARE
	@identity	NUMERIC(38, 0)
	, @error		INT

EXECUTE @error = usp_BasicInsertEntities
	null
	, 'Entity Name'
	, @identity OUTPUT

SELECT @error AS [Return Error]
SELECT @identity AS [Scope Identity]

SELECT * FROM [Entities] WHERE [EntityID] = @identity


