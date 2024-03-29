/*
   Tuesday, October 27, 20204:23:46 PM
   User: 
   Server: ADMIN\SQLEXPRESS
   Database: CodeGymDb
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Course ADD
	CreatedDate datetime NULL,
	CreatedBy int NULL,
	ModifiedDate datetime NULL,
	ModifiedBy int NULL
GO
ALTER TABLE dbo.Course SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Course', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Course', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Course', 'Object', 'CONTROL') as Contr_Per 