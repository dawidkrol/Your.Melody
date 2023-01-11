CREATE PROCEDURE [dbo].[spPlaylist_Add]
	@Id uniqueidentifier,
	@GameId uniqueidentifier
AS
	INSERT INTO [dbo].[Playlists](Id,GameId) 
	VALUES(@Id,@GameId)
GO;
