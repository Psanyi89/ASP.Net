CREATE TABLE [dbo].[states] (
    [StateId]   INT          NOT NULL,
    [StateName] VARCHAR (30) NOT NULL,
    [CountryId] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([StateId] ASC),
    CONSTRAINT [FK_states_countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[countries] ([id])
);

