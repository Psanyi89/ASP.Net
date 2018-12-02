CREATE procedure [dbo].[uspChooseStates]
@Id int
as
begin
select states.StateId, states.StateName,states.CountryId  from states where @Id=states.CountryId
end