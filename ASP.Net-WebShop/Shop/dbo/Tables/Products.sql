CREATE TABLE [dbo].[Products] (
    [productId] INT           IDENTITY (1, 1) NOT NULL,
    [product]   NVARCHAR (50) NOT NULL,
    [ean]       NVARCHAR (50) NOT NULL,
    [onstock]   INT           NULL,
    [price]     MONEY         NOT NULL,
    [modified]  DATETIME2 (0) DEFAULT (getutcdate()) NULL,
    PRIMARY KEY CLUSTERED ([productId] ASC)
);

