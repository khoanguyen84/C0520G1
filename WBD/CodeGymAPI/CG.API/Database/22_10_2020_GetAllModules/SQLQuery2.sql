USE [CodeGymManagementDb]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetModules]    Script Date: 10/22/2020 9:14:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 Le Thien Hong Son
-- Create date: 22/10/2020
-- Description:	Get all Module with status is actived
-- status: 1: Active, 2: Hoder, 3: InActive
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetModules] 
AS
BEGIN
	  SELECT [ModuleId]
      ,[ModuleName]
      ,[Duration]
      ,[Status]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
	  ,FORMAT([CreatedDate],'MMM dd yyyy') AS CreatedDateStr
	  ,FORMAT([ModifiedDate],'MMM dd yyyy') AS ModifiedDateStr
    FROM [dbo].[Module]
	WHERE [Status] = 1
END