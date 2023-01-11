CREATE PROCEDURE [dbo].[spPlayer_Add]
	@Id uniqueidentifier,
	@Name nvarchar(25),
	@GameId uniqueidentifier,
	@UserId uniqueidentifier = null
AS
	INSERT INTO [dbo].[Players](Id,[Name],GameId,UserId) VALUES(@Id,@Name,@GameId,@UserId);
GO;
