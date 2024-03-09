IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'DataBaseTeste')
	BEGIN
		CREATE DATABASE [DataBaseTeste]
    END
GO