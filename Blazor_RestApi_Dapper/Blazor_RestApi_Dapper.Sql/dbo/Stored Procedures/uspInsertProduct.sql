CREATE PROCEDURE [dbo].[uspInsertProduct]
	@Name nvarchar(max),
	@Quantity int,
	@Price money
AS
begin
	declare @Items int
	if not exists(select 1 from Products where Name = @Name and Price = @Price)
		begin
		insert into Products (Name,Quantity,Price) OUTPUT INSERTED.* values (@Name, @Quantity, @Price)
		end
			else begin
				return 0;
			end
end