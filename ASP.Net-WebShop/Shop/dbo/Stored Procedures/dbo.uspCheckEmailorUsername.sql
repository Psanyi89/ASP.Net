create procedure dbo.uspCheckEmailorUserName 
@text nvarchar(50),
@selection int out
as
begin
set @selection=(select count(username) from Customers where email=@text or username=@text)
select @selection
end