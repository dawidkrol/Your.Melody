CREATE TABLE [dbo].[Games]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PlaylistId] UNIQUEIDENTIFIER NOT NULL, 
    [GameModeId] INT NOT NULL, 
    [IsEnded] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Games_ToPlaylist] FOREIGN KEY ([PlaylistId]) REFERENCES [Playlists]([Id]), 
    CONSTRAINT [FK_Games_ToGameMode] FOREIGN KEY ([GameModeId]) REFERENCES [GameModes]([Id])
)
