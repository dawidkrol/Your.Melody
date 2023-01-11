CREATE PROCEDURE [dbo].[spPlayer_Edit]
	@playerId uniqueidentifier,
	@NewName nvarchar(25)
AS
	UPDATE [dbo].Players SET [Name] = @NewName
	WHERE Id = @playerId
GO
