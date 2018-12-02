create procedure dbo.uspGetCity
@CityId int
as begin
select cities.CityName from cities where CityId=@CityId
end