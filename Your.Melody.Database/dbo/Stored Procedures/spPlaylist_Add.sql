CREATE PROCEDURE [dbo].[spPlaylist_Add]
	@Id uniqueidentifier,
	@URI nvarchar(MAX)
AS
	INSERT INTO [dbo].[Playlists](Id,URI) 
	VALUES(@Id,@URI)
GO;
