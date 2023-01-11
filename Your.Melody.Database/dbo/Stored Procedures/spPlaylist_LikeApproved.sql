CREATE PROCEDURE [dbo].[spPlaylist_LikeApproved]
	@Id uniqueidentifier
AS
	UPDATE [dbo].[Playlists] SET Likes = Likes + 1
	WHERE Id = @Id AND IsApproved = 1
GO
