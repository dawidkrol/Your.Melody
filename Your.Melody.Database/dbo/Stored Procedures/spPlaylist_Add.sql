CREATE PROCEDURE [dbo].[spPlaylist_Add]
	@Id uniqueidentifier
AS
	INSERT INTO [dbo].[Playlists](Id) 
	VALUES(@Id)
GO;
