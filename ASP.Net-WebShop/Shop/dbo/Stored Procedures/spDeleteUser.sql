CREATE procedure [dbo].[spDeleteUser]
@Username nvarchar(50),
@Password nvarchar(50)
as
begin
delete from Customers where Customers.username=@Username and Customers.passwd=@Password
end