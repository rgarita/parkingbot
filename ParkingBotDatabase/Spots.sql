CREATE TABLE [dbo].[Spots]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Active] BIT NOT NULL
)

GO

CREATE INDEX [IX_Spots_Name] ON [dbo].[Spots] ([Name])
