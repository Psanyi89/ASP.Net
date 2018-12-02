CREATE procedure [dbo].[spInsertCustomer] 
@Username nvarchar(50),
@Firstname nvarchar(50),
@Lastname nvarchar(50),
@Phonenumber nvarchar(50),
@Email nvarchar(50),
@Passwd nvarchar(max),
@Birthdate date,
@Country nvarchar(50),
@States nvarchar(50),
@Zipcode nvarchar(50),
@Settlement nvarchar(50),
@Addresses nvarchar(50)
as
begin
insert dbo.Customers(
username,
firstname,
lastname,
phonenumber,
email,
passwd,
birthdate,
country,
states,
zipcode,
settlement,
addresses)
values(@Username,
@Firstname,
@Lastname,
@Phonenumber,
@Email,
@Passwd,
@Birthdate,
@Country,
@States,
@Zipcode,
@Settlement,
@Addresses)
end