CREATE PROCEDURE [dbo].[spPlayer_GetBySongId]
	@songId uniqueidentifier
AS
	SELECT p.Id,p.GameId,p.[Name],p.Points,p.Rounds,p.UserId FROM [dbo].[Songs] s
	LEFT JOIN [dbo].[Answers] a ON a.SongId = s.Id
	LEFT JOIN [dbo].[Players] p ON p.Id = a.PlayerId
	WHERE s.Id = @songId
GO;
