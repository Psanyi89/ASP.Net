create procedure dbo.uspGetAllCustomers
as 
begin
select Customers.username,Customers.firstname,Customers.lastname,Customers.phonenumber,Customers.email,
Customers.birthdate,Customers.country,Customers.states,Customers.zipcode,Customers.settlement,Customers.addresses,Customers.modified
from dbo.Customers
end