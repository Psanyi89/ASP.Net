CREATE procedure [dbo].[uspCheckEmailorUserName] 
@Text nvarchar(50)
as
begin
set nocount on
select count(username) from Customers where email=@Text or username=@Text
end