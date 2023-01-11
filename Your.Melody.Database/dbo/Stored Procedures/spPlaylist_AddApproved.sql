CREATE PROCEDURE [dbo].[spPlaylist_AddApproved]
	@Id uniqueidentifier,
	@URI nvarchar(MAX),
	@Name nvarchar(50),
	@Description nvarchar(MAX)
AS
	INSERT INTO [dbo].[Playlists](Id,URI,[Name],[Description],IsApproved)
	VALUES(@Id,@URI,@Name,@Description,1)
GO;
