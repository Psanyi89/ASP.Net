create procedure dbo.uspChooseStates
@Id int
as
begin
select states.StateId, states.StateName from states where @Id=states.CountryId
end
