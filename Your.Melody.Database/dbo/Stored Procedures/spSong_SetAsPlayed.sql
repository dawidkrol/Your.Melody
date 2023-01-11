CREATE PROCEDURE [dbo].[spSong_SetAsPlayed]
	@songId uniqueidentifier
AS
	UPDATE [dbo].Songs SET WasPlayed = 1
	WHERE Id = @songId;
GO
