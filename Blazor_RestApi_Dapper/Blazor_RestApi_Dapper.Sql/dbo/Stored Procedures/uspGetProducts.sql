CREATE PROCEDURE [dbo].[uspGetProducts]
	@ProductId int=null,
	@Name nvarchar(max)=null,
	@Quantity int=null,
	@Price money=null
AS
	begin
		select * from Products where (@ProductId=ProductId or @ProductId is null) and
									 (CHARINDEX(@Name,Name)>0 or @Name is null) and
									 (@Quantity=Quantity or @Quantity is null) and
									 (@Price=Price or @Price is null)
	end