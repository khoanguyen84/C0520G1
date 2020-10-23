USE [CodeGymDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCourseById]    Script Date: 10/23/2020 8:39:20 AM ******/
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
SELECT [CourseId]
      ,[CourseName]
      ,[StartDate]
      ,[EndDate]
	  ,FORMAT([StartDate],'dd/MM/yyyy') AS StartDateStr
	  ,FORMAT([EndDate],'dd/MM/yyyy') AS EndDateStr
  FROM [dbo].[Course]
  WHERE CourseId = @CourseId
END
