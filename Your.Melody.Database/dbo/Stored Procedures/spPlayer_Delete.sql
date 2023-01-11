CREATE PROCEDURE [dbo].[spPlayer_Delete]
	@playerId uniqueidentifier
AS
	UPDATE [dbo].Players SET [IsActive] = 0
	WHERE Id = @playerId
GO
