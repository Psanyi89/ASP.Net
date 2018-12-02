CREATE TABLE [dbo].[countries] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [sortname]  VARCHAR (3)   NOT NULL,
    [name]      VARCHAR (150) NOT NULL,
    [phonecode] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

