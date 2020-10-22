USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourses]    Script Date: 10/22/2020 4:46:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Khoa Nguyen
-- Create date: 22/10/2020
-- Description:	Get all sources with status is actived
-- status: 1: inprocess, 2: granded, 3: deleted
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetCourses] 
AS
BEGIN

	SELECT [CourseId]
		  ,[CourseName]
		  ,[Status]
		  ,[StartDate]
		  ,[EndDate]
		  ,FORMAT([StartDate],'MMM dd yyyy') AS StartDateStr
		  ,FORMAT([EndDate],'MMM dd yyyy') AS EndDateStr
	  FROM [dbo].[Course]
	WHERE [Status] = 1
END
GO


