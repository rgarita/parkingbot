CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] NVARCHAR(50) NOT NULL, 
    [DisplayName] NVARCHAR(50) NULL, 
    [Source] NVARCHAR(50) NULL
)

GO

CREATE INDEX [IX_Users_UserId] ON [dbo].[Users] ([UserId])
