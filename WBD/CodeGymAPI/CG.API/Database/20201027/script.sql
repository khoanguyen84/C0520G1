USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourses]    Script Date: 10/27/2020 4:25:40 PM ******/
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
		  ,(CASE WHEN [Status] = 1 THEN 'Inprocess' ELSE 'Completed' END) AS 'StatusName'
	  FROM [dbo].[Course]
	WHERE [Status] IN (1,2)
END
GO

/****** Object:  StoredProcedure [dbo].[sp_SaveCourse]    Script Date: 10/27/2020 4:25:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Phan Tiến Long
-- Create date: 2/11/2020
-- Description:	Create or update Course
-- Status : 1 - Actived; 2 -Inactived; 3-Deleted
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveCourse]
	   @CourseId int,
	   @CourseName nvarchar(50),
       @Status int,
       @StartDate date,
	   @EndDate date
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = 'Something went wrong, please try again later!'
	BEGIN TRY
		-- Create
		--IF(@CourseId IS NULL OR @CourseId = 0)
		IF(ISNULL(@CourseId,0) = 0)
		BEGIN
		IF(ISDATE(CONVERT(DATEtime,@StartDate)) = 1 AND ISDATE(CONVERT(DATEtime,@EndDate)) = 1 AND DATEDIFF(day,CONVERT(DATEtime,@StartDate) ,CONVERT(DATEtime,@EndDate) ) > 0 )
		BEGIN
			IF(NOT EXISTS(SELECT * FROM Course WHERE LOWER(RTRIM(LTRIM(CourseName))) = LOWER(RTRIM(LTRIM(@CourseName)))))
			BEGIN
				IF(@Status =  1 OR @Status = 2 OR @Status = 3)
				BEGIN
					INSERT INTO [dbo].[Course]
						   ([CourseName]
						   ,[Status]
						   ,[StartDate]
						   ,[EndDate]
						   ,[CreatedBy]
						   ,[CreatedDate]
						   ,[ModifiedBy]
						   ,[ModifiedDate])
					 VALUES
						   (@CourseName
						   ,@Status
						   ,@StartDate
						   ,@EndDate
						   ,1
						   ,GETDATE()
						   ,1
						   ,GETDATE())
					SET @Message = 'Course has been created success'
					SET @CourseId = SCOPE_IDENTITY()
				END
				ELSE
				BEGIN
					SET @Message = 'Invalid status value'
				END
			END
			ELSE
			BEGIN
				SET @Message = 'Course name is used'
			END
		END
		ELSE
		BEGIN
		SET @Message = 'StartDate or Enddate is malformed'
		END
		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM Course WHERE CourseId = @CourseId))
			BEGIN
				SET @Message = 'Course Id not found'
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM Course
					 WHERE CourseId != @CourseId AND
					 LOWER(RTRIM(LTRIM(CourseName))) = LOWER(RTRIM(LTRIM(@CourseName)))))
				BEGIN
					IF(@Status =  1 OR @Status = 2 OR @Status = 3)
					BEGIN
						UPDATE [dbo].[Course]
						   SET [CourseName] = @CourseName
							  ,[Status] = @Status
							  ,[StartDate] = @StartDate
							  ,[EndDate] = @EndDate
							  ,[ModifiedBy] = 1
						   ,[ModifiedDate] = GETDATE()
						 WHERE CourseId = @CourseId
						 SET @Message = 'Course has been updated success'
					END
					ELSE
					BEGIN
						SET @Message = 'Invalid status value'
					END
				END
				ELSE
				BEGIN
					SET @Message = 'Course name is used'
				END
			END
		END
		SELECT @Message AS [Message], @CourseId AS CourseId
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @CourseId AS CourseId
	END CATCH
END
GO

