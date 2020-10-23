USE [CodeGymDb]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 10/23/2020 11:01:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Tung 
-- Create date: 23/10/2020
-- Description:	Update Course by Id
-- =============================================
ALTER PROCEDURE [dbo].[UpdateCourse]
	@Id INT,
	@CourseName NVARCHAR(50),
	@StartDate DATE,
	@EndDate DATE,
	@Status INT
AS
BEGIN

UPDATE [dbo].[Course]
   SET [CourseName] = @CourseName
      ,[Status] = @Status
      ,[StartDate] = @StartDate
      ,[EndDate] = @EndDate
 WHERE CourseId = @Id
 SELECT @Id AS CourseId

END
