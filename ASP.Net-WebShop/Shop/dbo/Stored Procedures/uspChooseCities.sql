
CREATE procedure [dbo].[uspChooseCities]
@Id int
as
begin
select cities.CityId,cities.CityName, cities.StateId from cities where @Id=cities.StateId
end
