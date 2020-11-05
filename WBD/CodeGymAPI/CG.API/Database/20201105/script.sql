USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetStudentsByCourseId]    Script Date: 11/5/2020 5:30:06 PM ******/
DROP PROCEDURE [dbo].[sp_GetStudentsByCourseId]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourse]    Script Date: 11/5/2020 5:30:06 PM ******/
DROP PROCEDURE [dbo].[sp_GetCourse]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourse]    Script Date: 11/5/2020 5:30:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Khoa Nguyen
-- Create date: 05/11/2020
-- Description:	Get course by id
-- status: 1: inprocess, 2: granded, 3: pending, 4: deleted
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetCourse] 
	@CourseId INT
AS
BEGIN

	SELECT c.[CourseId]
		  ,c.[CourseName]
		  ,c.[Status]
		  ,c.[StartDate]
		  ,c.[EndDate]
		  ,FORMAT(c.[StartDate],'MMM dd yyyy') AS StartDateStr
		  ,FORMAT(c.[EndDate],'MMM dd yyyy') AS EndDateStr
		  ,(SELECT TOP(1) StatusName FROM Wiki WHERE TableId = 1 AND [Status] = c.[Status] AND IsDelete = 0) AS 'StatusName'
	  FROM [dbo].[Course] AS c
	WHERE [Status] IN (1,2,3) AND c.CourseId = @CourseId
END
GO

/****** Object:  StoredProcedure [dbo].[sp_GetStudentsByCourseId]    Script Date: 11/5/2020 5:30:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Khoa Nguyen
-- Create date: 05/11/2020
-- Description:	Get students by CourseId
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetStudentsByCourseId] 
	@CourseId	INT
AS
BEGIN
	SELECT s.[StudentId]
		  ,s.[Fullname]
		  ,s.[Gender]
		  ,(CASE WHEN s.Gender = 1 THEN 'Nam' ELSE N'Nữ' END) AS GenderStr
		  ,s.[Dob]
		  ,FORMAT(s.[Dob], 'dd/MM/yyyy') AS DobStr
		  ,s.[Email]
		  ,s.[PhoneNumber]
		  ,s.[Address]
		  ,s.[Avatar]
		  ,s.[Status]
		  ,(SELECT TOP(1) StatusName FROM Wiki WHERE TableId = 4 AND [Status] = s.[Status] AND IsDelete = 0) AS 'StatusName'
	  FROM [dbo].[Student] s INNER JOIN [dbo].[CourseStudent] cs ON s.StudentId = cs.StudentId
	  WHERE cs.CourseId = @CourseId
END
GO

------------------------------------
USE [CodeGymDb]
GO
SET IDENTITY_INSERT [dbo].[Wiki] ON 

INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (10, 4, N'Student', 1, N'Active', 0)
INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (11, 4, N'Student', 2, N'Blocked', 0)
INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (12, 4, N'Student', 3, N'Granded', 0)
INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (13, 4, N'Student', 4, N'Deleted', 0)
SET IDENTITY_INSERT [dbo].[Wiki] OFF