create procedure dbo.uspDeleteUser
@username nvarchar(50),
@password nvarchar(50)
as
begin
delete from Customers where Customers.username=@username and Customers.passwd=@password
end