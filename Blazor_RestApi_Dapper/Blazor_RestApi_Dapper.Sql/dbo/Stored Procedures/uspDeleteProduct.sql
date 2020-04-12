CREATE PROCEDURE [dbo].[uspDeleteProduct]
	@ProductId int
AS
begin
	delete from Products OUTPUT DELETED.* where ProductId=@ProductId
end
