create procedure dbo.uspLogin
@Username nvarchar(50),
@Password nvarchar(50),
@selection int out
as
begin
set @selection=(select COUNT(username) from Customers where Customers.username=@userName and Customers.passwd=@Password)
select @selection
end