USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourses]    Script Date: 10/22/2020 4:46:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 My
-- Create date: 23/10/2020
-- Description:	Change Status Module By ModuleId
-- status: 1: inprocess, 2: granded, 3: deleted
-- =============================================
ALTER PROC [dbo].[sp_ChangeStatusModuleByModuleId]( 
 @moduleId int,
 @status int
 ) 
AS 
 BEGIN 
 UPDATE [dbo].[Module] 
SET [Status] = @status 
WHERE [ModuleId] = @moduleId
SELECT [ModuleId],[Status]
FROM Module WHERE [ModuleId]=@moduleId
END
GO

USE [CodeGymDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetModuleByModuleId]    Script Date: 10/23/2020 11:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[sp_GetModuleByModuleId]( 
 @moduleId int
 ) 
AS 
 BEGIN 
 SELECT TOP(1) [ModuleId],[Status]
 FROM [dbo].[Module]
 WHERE [ModuleId]=@moduleId
 END


