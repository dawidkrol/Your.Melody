﻿CREATE TABLE [dbo].[ApprovedPlaylists]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [URI] NVARCHAR(MAX) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Likes] INT NOT NULL DEFAULT 0, 
    [Dislikes] INT NOT NULL DEFAULT 0, 
    [IsActive] BIT NOT NULL DEFAULT 1
)
