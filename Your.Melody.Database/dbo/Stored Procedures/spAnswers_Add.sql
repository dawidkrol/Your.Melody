CREATE PROCEDURE [dbo].[spAnswers_Add]
	@gameId uniqueidentifier,
	@playerId uniqueidentifier,
	@songId uniqueidentifier
AS
	INSERT INTO [dbo].Answers(GameId,PlayerId,SongId,Points)
	VALUES(@gameId,@playerId,@songId,0)
GO;
