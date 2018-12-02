create procedure dbo.uspGetCountries
as 
begin
set nocount on
select countries.id, countries.name from countries
end