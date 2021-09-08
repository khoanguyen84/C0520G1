USE [CodeGymDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_SaveModule]    Script Date: 10/26/2020 4:00:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Khoa Nguyễn
-- Create date: 23/10/2020
-- Description:	Create or update Module
-- Status : 1 - Actived; 2 -Inactived; 3-Deleted 
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveModule] 
	@ModuleId		INT,
	@ModuleName		NVARCHAR(200),
	@Duration		INT,
	@Status			INT,
	@SavedBy		INT
AS
BEGIN
	DECLARE @Message NVARCHAR(100) = 'Something went wrong, please try again later!'
	BEGIN TRY
		-- Create
		--IF(@ModuleId IS NULL OR @ModuleId = 0)
		IF(ISNULL(@ModuleId,0) = 0)
		BEGIN
			IF(NOT EXISTS(SELECT * FROM Module WHERE LOWER(RTRIM(LTRIM(ModuleName))) = LOWER(RTRIM(LTRIM(@ModuleName)))))
			BEGIN
				IF(@Status =  1 OR @Status = 2 OR @Status = 3)
				BEGIN

					INSERT INTO [dbo].[Module]
						   ([ModuleName]
						   ,[Duration]
						   ,[Status]
						   ,[CreatedDate]
						   ,[CreatedBy]
						   ,[ModifiedDate]
						   ,[ModifiedBy])
					 VALUES
						   (@ModuleName
						   ,@Duration
						   ,@Status
						   ,GETDATE()
						   ,@SavedBy
						   ,GETDATE()
						   ,@SavedBy)
					SET @Message = 'Module has been created success'
					SET @ModuleId = SCOPE_IDENTITY()
				END
				ELSE
				BEGIN
					SET @Message = 'Invalid status value'
				END
			END
			ELSE
			BEGIN
				SET @Message = 'Module name is used'
			END
		END
		ELSE --Update
		BEGIN
			IF(NOT EXISTS(SELECT * FROM Module WHERE ModuleId = @ModuleId))
			BEGIN
				SET @Message = 'Module Id not found'
			END
			ELSE
			BEGIN
				IF(NOT EXISTS(SELECT TOP(1) * FROM Module
					 WHERE ModuleId != @ModuleId AND 
					 LOWER(RTRIM(LTRIM(ModuleName))) = LOWER(RTRIM(LTRIM(@ModuleName)))))

				BEGIN
					IF(@Status =  1 OR @Status = 2 OR @Status = 3)
					BEGIN

						UPDATE [dbo].[Module]
						   SET [ModuleName] = @ModuleName
							  ,[Duration] = @Duration
							  ,[Status] = @Status
							  ,[ModifiedDate] = GETDATE()
							  ,[ModifiedBy] = @SavedBy
						 WHERE ModuleId = @ModuleId

						 SET @Message = 'Module has been updated success'

					END
					ELSE
					BEGIN
						SET @Message = 'Invalid status value'
					END
				END
				ELSE
				BEGIN
					SET @Message = 'Module name is used'
				END
			END
		END
		SELECT @Message AS [Message], @ModuleId AS ModuleId
	END TRY
	BEGIN CATCH
		SELECT @Message AS [Message], @ModuleId AS ModuleId
	END CATCH
END
GO

