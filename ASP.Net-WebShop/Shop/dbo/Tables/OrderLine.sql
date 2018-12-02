CREATE TABLE [dbo].[OrderLine] (
    [orderId]   INT NOT NULL,
    [productId] INT NOT NULL,
    [quantity]  INT NOT NULL,
    CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED ([orderId] ASC, [productId] ASC)
);

