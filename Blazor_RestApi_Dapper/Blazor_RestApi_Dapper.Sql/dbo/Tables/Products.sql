CREATE TABLE [dbo].[Products]
(
	[ProductId] [int] IDENTITY(1,1) Not Null,
	[Name] [nvarchar](max) Null,
	[Quantity] [int] null,
	[Price] MONEY null,
	CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED
	(
	[ProductId] ASC
	)With (PAD_INDEX = Off, statistics_norecompute = off, ignore_dup_key = off, Allow_row_locks = on, Allow_Page_Locks = on)on [Primary]
)on [PRIMARY] textimage_on [PRIMARY]
go
