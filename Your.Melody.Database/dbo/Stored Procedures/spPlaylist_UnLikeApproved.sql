CREATE PROCEDURE [dbo].[spPlaylist_UnLikeApproved]
	@Id uniqueidentifier
AS
	UPDATE [dbo].[Playlists] SET Dislikes = Dislikes + 1
	WHERE Id = @Id AND IsApproved = 1
GO
