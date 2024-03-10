USE [master]
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'DataBaseTeste')
	BEGIN
		DROP DATABASE [DataBaseTeste]
    END
GO