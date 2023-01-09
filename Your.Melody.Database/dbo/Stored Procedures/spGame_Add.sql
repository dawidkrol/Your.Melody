CREATE PROCEDURE [dbo].[spGame_Add]
	@Id uniqueidentifier,
	@GameMode int
AS
	INSERT INTO [dbo].[Games](Id,GameModeId) VALUES(@Id,@GameMode);
GO;

