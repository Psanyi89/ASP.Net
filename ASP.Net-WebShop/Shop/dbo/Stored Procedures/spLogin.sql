CREATE procedure [dbo].[spLogin]
@Username nvarchar(50),
@Password nvarchar(max)
as
begin
select count(Customers.username) from Customers where Customers.username=@Username and Customers.passwd=@Password
end