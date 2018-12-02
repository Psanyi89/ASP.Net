create procedure dbo.uspCheckCityName
@CityName nvarchar(50)
as
begin
select COUNT(cities.CityId) from cities where cities.CityName=@CityName
end