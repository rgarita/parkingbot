CREATE TABLE [dbo].[Reservations]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdUser] INT NOT NULL, 
    [IdSpot] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [Comments] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Reservations_To_Users] FOREIGN KEY ([IdUser]) REFERENCES [Users](Id), 
    CONSTRAINT [FK_Reservations_Spots] FOREIGN KEY ([IdSpot]) REFERENCES [Spots]([Id])
)

GO

CREATE INDEX [IX_Reservations_IdUserIdSpotStartDateEndDate] ON [dbo].[Reservations] ([IdUser],[IdSpot],[StartDate],[EndDate])
