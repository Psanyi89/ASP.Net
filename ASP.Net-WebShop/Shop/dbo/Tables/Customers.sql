CREATE TABLE [dbo].[Customers] (
    [username]    NVARCHAR (50)  NOT NULL,
    [firstname]   NVARCHAR (50)  NOT NULL,
    [lastname]    NVARCHAR (50)  NOT NULL,
    [phonenumber] NVARCHAR (50)  NOT NULL,
    [email]       NVARCHAR (50)  NOT NULL,
    [passwd]      NVARCHAR (MAX) NOT NULL,
    [birthdate]   DATE           NOT NULL,
    [country]     NVARCHAR (50)  NOT NULL,
    [states]      NVARCHAR (50)  NULL,
    [zipcode]     NVARCHAR (50)  NULL,
    [settlement]  NVARCHAR (50)  NOT NULL,
    [addresses]   NVARCHAR (50)  NOT NULL,
    [modified]    DATETIME2 (0)  DEFAULT (getutcdate()) NULL
);

