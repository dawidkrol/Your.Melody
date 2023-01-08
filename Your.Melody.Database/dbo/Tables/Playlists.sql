﻿CREATE TABLE [dbo].[Playlist]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [URI] NVARCHAR(255) NOT NULL, 
    [IsActive] BIT NOT NULL
)
