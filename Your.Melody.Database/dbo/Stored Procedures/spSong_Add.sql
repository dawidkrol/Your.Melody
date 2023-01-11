CREATE PROCEDURE [dbo].[spSong_Add]
	@Id uniqueidentifier,
	@Title nvarchar(255),
	@Artist nvarchar(255),
	@VideoUrl nvarchar(255),
	@AudioUrl nvarchar(255),
	@PlaylistId uniqueidentifier,
	@SecToStart int
AS
	INSERT INTO [dbo].[Songs](Id,Title,Artist,VideoUrl,AudioUrl,PlaylistId,SecToStart)
	VALUES(@Id,@Title,@Artist,@VideoUrl,@AudioUrl,@PlaylistId,@SecToStart)
GO;
