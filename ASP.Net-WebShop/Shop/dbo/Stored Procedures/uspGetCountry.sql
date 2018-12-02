CREATE procedure [dbo].[uspGetCountry]
@Id int
as begin
select countries.name from countries where id=@Id
end