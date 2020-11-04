USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourses]    Script Date: 10/30/2020 4:00:01 PM ******/
DROP PROCEDURE [dbo].[sp_GetCourses]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetStatus]    Script Date: 10/30/2020 4:00:01 PM ******/
DROP PROCEDURE [dbo].[sp_GetStatus]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetStatus]    Script Date: 10/30/2020 4:00:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Khoa Nguyen
-- Create date: 30/10/2020
-- Description:	Get status by TableId
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetStatus] 
	@TableId	INT
AS
BEGIN

	SELECT [Status] AS Id
			,StatusName AS [Name]
	  FROM [dbo].[Wiki]
	WHERE TableId = @TableId AND IsDelete = 0 AND StatusName != 'Deleted'
END
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourses]    Script Date: 10/30/2020 4:00:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Khoa Nguyen
-- Create date: 22/10/2020
-- Description:	Get all sources with status is actived
-- status: 1: inprocess, 2: granded, 3: pending, 4: deleted
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetCourses] 
AS
BEGIN

	SELECT c.[CourseId]
		  ,c.[CourseName]
		  ,c.[Status]
		  ,c.[StartDate]
		  ,c.[EndDate]
		  ,FORMAT(c.[StartDate],'MMM dd yyyy') AS StartDateStr
		  ,FORMAT(c.[EndDate],'MMM dd yyyy') AS EndDateStr
		  --,(CASE WHEN [Status] = 1 THEN 'Inprocess' ELSE 'Completed' END) AS 'StatusName'
		  ,(SELECT TOP(1) StatusName FROM Wiki WHERE TableId = 1 AND [Status] = c.[Status] AND IsDelete = 0) AS 'StatusName'
	  FROM [dbo].[Course] AS c
	WHERE [Status] IN (1,2,3)
END
GO

