CREATE PROCEDURE [dbo].[spPlaylist_GetApprovedById]
	@Id uniqueidentifier
AS
	SELECT *
	FROM [dbo].[Playlists] p
	WHERE Id = @Id AND IsActive = 1 AND IsApproved = 1
GO;
