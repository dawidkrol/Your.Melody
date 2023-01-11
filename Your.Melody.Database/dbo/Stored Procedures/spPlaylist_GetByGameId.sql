CREATE PROCEDURE [dbo].[spPlaylist_GetByGameId]
	@GameId uniqueidentifier
AS
	SELECT *
	FROM [dbo].[Playlists] p
	WHERE @GameId = p.GameId AND IsActive = 1
GO;
