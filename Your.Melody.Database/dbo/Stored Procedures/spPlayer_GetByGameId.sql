CREATE PROCEDURE [dbo].[spPlayer_GetByGameId]
	@GameId uniqueidentifier
AS
	SELECT *
	FROM [dbo].[Players] p
	WHERE @GameId = p.GameId
GO;
