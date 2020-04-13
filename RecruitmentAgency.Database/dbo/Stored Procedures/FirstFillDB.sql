CREATE Proc [dbo].[FirstFillDB]
AS
BEGIN
	INSERT INTO [dbo].[Roles]
	SELECT 1 AS [Id]
		  ,'Admin' AS [Name]
	UNION
	SELECT 2 AS [Id]
		  ,'HR' AS [Name]
	UNION
	SELECT 3 AS [Id]
		  ,'Employee' AS [Name]
	UNION
	SELECT 4 AS [Id]
		  ,'Jobseeker' AS [Name]

	INSERT INTO [dbo].[Users]
	SELECT 'Admin' AS [Login]
		  ,'admin@admin.ru' AS [Email]
		  ,'Admin' AS [Password]
		  ,1 AS [RoleId]
	UNION 
	SELECT 'HR' AS [Login]
		  ,'hr@hr.ru' AS [Email]
		  ,'HR' AS [Password]
		  ,2 AS [RoleId]
	UNION 
	SELECT 'Employee' AS [Login]
		  ,'employee@employee.ru' AS [Email]
		  ,'Employee' AS [Password]
		  ,3 AS [RoleId]
	UNION 
	SELECT 'Jobseeker' AS [Login]
		  ,'jobseeker@jobseeker.ru' AS [Email]
		  ,'Jobseeker' AS [Password]
		  ,4 AS [RoleId]

	INSERT INTO [dbo].[Skills]
	SELECT 1 AS [Id]
	      ,'ASP.NET' AS [Name]
	UNION 
	SELECT 2 AS [Id]
	      ,'C#' AS [Name]
	UNION 
	SELECT 3 AS [Id]
	      ,'C' AS [Name]
	UNION 
	SELECT 4 AS [Id]
	      ,'C++' AS [Name]
	UNION 
	SELECT 5 AS [Id]
	      ,'Java' AS [Name]
	UNION 
	SELECT 6 AS [Id]
	      ,'Python' AS [Name]
END