CREATE TABLE [dbo].[Dominion]
(
	[Card] NCHAR(50) NOT NULL PRIMARY KEY, 
    [Set] VARCHAR(MAX) NOT NULL, 
    [Url] VARCHAR(MAX) NOT NULL, 
    [Price] INT NOT NULL, 
    [Type] VARCHAR(MAX) NOT NULL,
    [PictureUrl] VARCHAR(MAX) NOT NULL
)