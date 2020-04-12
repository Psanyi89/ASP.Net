CREATE PROCEDURE [dbo].[uspUpdateProduct]
	@ProductId int,
	@Name nvarchar(max)=null,
	@Quantity int=null,
	@Price money=null
AS
	begin
		update Products set Name=ISNULL(@Name,Name), Quantity=ISNULL(@Quantity,Quantity), Price=ISNULL(@Price,Price)
		OUTPUT INSERTED.*
		where @ProductId=ProductId
	end