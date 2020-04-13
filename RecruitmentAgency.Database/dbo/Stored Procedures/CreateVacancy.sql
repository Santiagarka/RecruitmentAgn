CREATE PROCEDURE [dbo].[CreateVacancy]
	@Name nvarchar(max),
	@Description nvarchar(max),
	@Term datetime2(0),
	@Company nvarchar(max),
	@Requirements nvarchar(max),
	@Salary decimal(10,2),
	@CreatorId int,
	@StringSkills nvarchar(max)
AS
BEGIN
	DECLARE @NewId int;
    BEGIN TRANSACTION
		INSERT INTO [dbo].[Vacancies]
			   ([Name]
			   ,[Description]
			   ,[Term]
			   ,[Company]
			   ,[Requirements]
			   ,[Salary]
			   ,[CreatorId])
		 VALUES
			   (@Name
			   ,@Description
			   ,@Term
			   ,@Company
			   ,@Requirements
			   ,@Salary
			   ,@CreatorId)
	SELECT @NewId = @@IDENTITY 

		INSERT INTO [dbo].[Vacancies_Skills]
				   ([VacancyId]
				   ,[SkillId])
			SELECT @NewId AS [Vacancy_id] 
			      ,value AS [SkillId]
			  FROM STRING_SPLIT(@StringSkills, '|')
    COMMIT;
END