CREATE ROLE [proc_executor]
    AUTHORIZATION [dbo];


GO
ALTER ROLE [proc_executor] ADD MEMBER [User];

