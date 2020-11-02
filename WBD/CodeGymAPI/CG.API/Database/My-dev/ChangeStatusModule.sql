USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetCourses]    Script Date: 10/22/2020 4:46:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		 My
-- Create date: 23/10/2020
-- Description:	Change Status Module By ModuleId
-- status: 1: active, 2: completed, 3: cancel
-- ModifiedBy > 0 AND ModifiedBy <= 10
-- =============================================
ALTER PROC [dbo].[sp_ChangeStatusModuleByModuleId]( 
 @moduleId		int,
 @status		int,
 @modifiedBy	int
 ) 
AS 
BEGIN
	DECLARE @Message NVARCHAR(200) = 'Something went wrong, please try again!'
	BEGIN TRY
		
		IF(NOT EXISTS(SELECT [ModuleId] FROM [dbo].[Module] WHERE [ModuleId]=@moduleId))
		BEGIN
			SET @Message = 'Module is not found!'		
		END
		ELSE --module exist
		BEGIN
			IF(@status IN(1,2,3))
				BEGIN
				IF(@modifiedBy>0 AND @modifiedBy<=10)
					BEGIN
						UPDATE [dbo].[Module] 
						SET [Status] = @status,
							[ModifiedBy]=@modifiedBy,
							[ModifiedDate]=GETDATE()
						WHERE [ModuleId] = @moduleId
						IF(@status=2)
							BEGIN 
								SET @Message = 'Changed module status to completed!'
							END
						ELSE IF(@status=3)
							BEGIN 
								SET @Message = 'Changed status module to cancel!'
							END
							ELSE BEGIN 
								SET @Message = 'Changed status module to active!'
							END
					END
					ELSE
				BEGIN 
					SET @Message = 'ModifiedBy is not found!'
				END		
				END
			ELSE
				BEGIN 
					SET @Message = 'Status invalid!'
				END			
		END
		SELECT @moduleId AS ModuleId, @Message AS [Message]

	END TRY
	BEGIN CATCH
		SET @moduleId = 0
		SELECT @moduleId AS ModuleId, @Message AS [Message]
	END CATCH
END









