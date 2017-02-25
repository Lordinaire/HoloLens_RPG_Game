CREATE TABLE [dbo].[Games]
(
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Ip] NVARCHAR (50) NOT NULL,
	[Title] NVARCHAR (200) NOT NULL,
    [Description] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC)
);
