CREATE procedure [dbo].[uspGetState]
@Id int
as begin
select states.StateName from states where StateId=@Id
end