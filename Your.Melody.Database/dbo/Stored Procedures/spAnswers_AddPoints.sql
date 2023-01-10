CREATE PROCEDURE [dbo].[spAnswers_AddPoints]
	@gameId uniqueidentifier,
	@playerId uniqueidentifier,
	@songId uniqueidentifier,
	@points float
AS
	UPDATE [dbo].Answers 
	SET Points = @points
	WHERE GameId = @gameId AND PlayerId = @playerId AND SongId = @songId
GO;
