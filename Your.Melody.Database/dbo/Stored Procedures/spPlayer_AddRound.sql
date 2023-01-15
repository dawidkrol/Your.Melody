CREATE PROCEDURE [dbo].[spPlayer_AddRound]
	@playerId uniqueidentifier,
	@rounds int
AS
	UPDATE [dbo].[Players] SET Rounds = Rounds + @rounds
	WHERE Id = @playerId
GO;