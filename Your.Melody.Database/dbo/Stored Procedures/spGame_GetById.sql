CREATE PROCEDURE [dbo].[spGame_GetById]
	@GameId uniqueidentifier
AS
	SELECT *
	FROM [dbo].[Games] g
	WHERE @GameId = g.Id
GO;