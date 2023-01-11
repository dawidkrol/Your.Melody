﻿CREATE TABLE [dbo].[Players]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(25) NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [Points] FLOAT NOT NULL DEFAULT 0, 
    [Rounds] INT NOT NULL DEFAULT 0, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Players_ToGame] FOREIGN KEY (GameId) REFERENCES Games(Id), 
    CONSTRAINT [FK_Players_ToUser] FOREIGN KEY (UserId) REFERENCES Users(Id)
)
