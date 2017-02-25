CREATE TABLE [dbo].[Maps]
(
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
	[Title] NVARCHAR (200) NOT NULL,
    [Description] NVARCHAR (200) NULL,
    [Height] INT NOT NULL, 
    [Width] INT NOT NULL,
    [JsonItems] NVARCHAR (2000) NULL, 
    [GameId] INT NOT NULL, 
    CONSTRAINT [FK_Map_Game] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] (Id),
);
