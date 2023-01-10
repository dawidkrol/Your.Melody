CREATE PROCEDURE [dbo].[spPlayer_AddPoints]
	@playerId uniqueidentifier,
	@points float
AS
	UPDATE [dbo].[Players] SET Points = @points
	WHERE Id = @playerId
GO;