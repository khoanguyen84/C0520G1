USE [CodeGymDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCourseById]    Script Date: 10/27/2020 12:36:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Khoa Hoang>
-- Create date: <22/10/2020>
-- Description:	<Get Course By Id>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetCourseById]
	@CourseId INT
AS
BEGIN

IF (NOT EXISTS(SELECT * FROM [dbo].[Course] WHERE @CourseId = CourseId))
BEGIN
	RAISERROR('Invalid Course Id', 1, 100)
	RETURN
END
SELECT [CourseId]
      ,[CourseName]
      ,[StartDate]
      ,[EndDate]
	  ,FORMAT([StartDate],'dd/MM/yyyy') AS StartDateStr
	  ,FORMAT([EndDate],'dd/MM/yyyy') AS EndDateStr
  FROM [dbo].[Course]
  WHERE CourseId = @CourseId 
END