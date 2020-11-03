USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetModules]    Script Date: 11/2/2020 5:23:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		 Khoa Nguyen
-- Create date: 02/11/2020
-- Description:	Get all module
-- status: 1: draft, 2: active, 3: inactive, 4: deleted
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetModules] 
AS
BEGIN

	SELECT m.[ModuleId]
		  ,m.[ModuleName]
		  ,m.[Duration]
		  ,m.[Status]
		  ,(SELECT TOP(1) StatusName FROM Wiki WHERE TableId = 2 AND [Status] = m.[Status] AND IsDelete = 0) AS 'StatusName'
	  FROM [dbo].[Module] m
	  WHERE m.[Status] IN (1,2,3)
END
GO

------------------------------------
USE [CodeGymDb]
GO
SET IDENTITY_INSERT [dbo].[Wiki] ON 

INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (6, 2, N'Module', 1, N'Draft', 0)
INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (7, 2, N'Module', 2, N'Active', 0)
INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (8, 2, N'Module', 3, N'Inactive', 0)
INSERT [dbo].[Wiki] ([Id], [TableId], [TableName], [Status], [StatusName], [IsDelete]) VALUES (9, 2, N'Module', 4, N'Deleted', 0)
SET IDENTITY_INSERT [dbo].[Wiki] OFF
