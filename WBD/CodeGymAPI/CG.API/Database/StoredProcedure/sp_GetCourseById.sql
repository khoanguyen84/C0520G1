USE [CodeGymDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCourseById]    Script Date: 10/28/2020 1:38:40 PM ******/
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
DECLARE @message nvarchar(200) ='Đã xảy ra lỗi ! Bạn hãy thử lại'
IF(EXISTS(SELECT [CourseId] FROM [dbo].[Course] WHERE [CourseId] = @CourseId))
BEGIN
	SELECT [CourseId]
		  ,[CourseName]
		  ,[Status]
		  ,FORMAT([StartDate],'MMM dd yyyy') AS StartDateStr		 
		  ,FORMAT([EndDate],'MMM dd yyyy') AS EndDateStr
	  FROM [dbo].[Course]
	  WHERE CourseId = @CourseId
END
ELSE
BEGIN
SET @message ='Không tìm thấy !'
SELECT @CourseId as CourserId, @message as [message]
END
END