CREATE PROCEDURE [dbo].[spPlaylist_GetApproved]
AS
	SELECT *
	FROM [dbo].[Playlists] p
	WHERE IsApproved = 1 AND IsActive = 1
GO;
