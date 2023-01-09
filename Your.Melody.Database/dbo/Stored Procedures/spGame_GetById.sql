CREATE PROCEDURE [dbo].[spGame_GetById]
	@GameId uniqueidentifier
AS
	SELECT *
	FROM [dbo].[Games] g
	LEFT JOIN [dbo].[Players] p ON g.Id = p.GameId
	JOIN [dbo].[Users] u ON p.UserId = u.Id
	WHERE @GameId = g.Id
GO;