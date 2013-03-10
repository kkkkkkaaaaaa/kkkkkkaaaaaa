USE [kkkkkkaaaaaa.Database.2010]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[usp_InsertMemberships]
		@id = NULL,
		@name = N'name',
		@password = N'password',
		@enabled = 1,
		@createdOn = '2000-1-1 11:12:13.0000001',
		@updatedOn = NULL

SELECT	'Return Value' = @return_value

GO
