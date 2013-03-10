DECLARE
	@identity	NUMERIC(38, 0)
	
EXECUTE usp_AdvancedInsertEntities 1, N'Preset Entity 1', @identity OUTPUT
SELECT @identity AS [Scope Identity]
EXECUTE usp_AdvancedInsertEntities 2, N'Preset Entity 2', @identity OUTPUT
SELECT @identity AS [Scope Identity]
EXECUTE usp_AdvancedInsertEntities 3, N'Preset Entity 3', @identity OUTPUT
SELECT @identity AS [Scope Identity]

EXECUTE usp_AdvancedInsertEntities 0, N'Entity', @identity OUTPUT
SELECT @identity AS [Scope Identity]

SELECT * FROM [Entities] ORDER BY [EntityID] ASC
