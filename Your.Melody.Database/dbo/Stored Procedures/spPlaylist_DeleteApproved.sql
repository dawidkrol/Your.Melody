CREATE PROCEDURE [dbo].[spPlaylist_DeleteApproved]
	@Id uniqueidentifier
AS
	UPDATE [dbo].[Playlists] SET IsActive = 0
	WHERE Id = @Id AND IsApproved = 1
GO
