/*
   Friday, October 30, 20202:51:32 PM
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
CREATE TABLE dbo.Wiki
	(
	Id int NOT NULL IDENTITY (1, 1),
	TableId int NOT NULL,
	TableName nvarchar(50) NOT NULL,
	Status int NOT NULL,
	StatusName nvarchar(50) NOT NULL,
	IsDelete bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Wiki ADD CONSTRAINT
	DF_Wiki_IsDelete DEFAULT 0 FOR IsDelete
GO
ALTER TABLE dbo.Wiki ADD CONSTRAINT
	PK_Wiki PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Wiki SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Wiki', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Wiki', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Wiki', 'Object', 'CONTROL') as Contr_Per 