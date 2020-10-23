USE [CodeGymDb]
GO
/****** Object:  StoredProcedure [dbo].[CourseCreate]    Script Date: 23/10/2020 01:39:24 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Huy Hiệu
-- Create date: 22/10/2020	
-- Description:	Create a new Course API
-- =============================================
ALTER PROCEDURE [dbo].[CourseCreate]
       -- Add the parameters for the stored procedure here
       @CourseName nvarchar(50),
       @Status int,
       @StartDate date,
	   @EndDate date
AS
BEGIN
       -- SET NOCOUNT ON added to prevent extra result sets from
       -- interfering with SELECT statements.
       SET NOCOUNT ON;

    -- Insert statements for procedure here
       INSERT INTO [dbo].[Course]
              ( [CourseName], [Status], [StartDate],[EndDate])
       VALUES
              ( @CourseName, @Status, @StartDate,@EndDate)
END



