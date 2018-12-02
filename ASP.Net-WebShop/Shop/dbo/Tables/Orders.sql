CREATE TABLE [dbo].[Orders] (
    [orderID]   INT           IDENTITY (1, 1) NOT NULL,
    [orderdate] DATETIME2 (0) DEFAULT (getutcdate()) NULL,
    [username]  NVARCHAR (50) NOT NULL
);

