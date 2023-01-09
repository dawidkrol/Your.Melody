CREATE PROCEDURE [dbo].[spSong_GetByPlaylistId]
	@PlaylistId uniqueidentifier
AS
	SELECT *
	FROM [dbo].[Songs] s
	WHERE @PlaylistId = s.PlaylistId
GO;
