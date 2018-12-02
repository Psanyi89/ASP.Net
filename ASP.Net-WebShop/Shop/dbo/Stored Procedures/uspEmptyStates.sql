
create procedure dbo.uspEmptyStates
as 
begin
select distinct * from states where states.StateId  not in (select cities.StateId from cities)
end