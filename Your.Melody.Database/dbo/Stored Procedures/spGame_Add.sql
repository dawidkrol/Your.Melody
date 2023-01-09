CREATE PROCEDURE [dbo].[spGame_Add]
	@Id uniqueidentifier,
	@GameMode int,
	@PlaylistId uniqueidentifier
AS
	INSERT INTO [dbo].[Games](Id,GameModeId,PlaylistId) VALUES(@Id,@GameMode,@PlaylistId);
GO;

