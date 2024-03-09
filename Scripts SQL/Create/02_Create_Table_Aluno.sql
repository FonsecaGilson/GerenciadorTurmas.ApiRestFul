USE [DataBaseTeste]
GO

If Object_Id('[dbo].[Aluno]') Is Null
	Create Table [dbo].[Aluno] ([Id] int Not Null Identity(1,1))
Go

If Not ColumnProperty (Object_Id('[dbo].[Aluno]') , 'Id', 'AllowsNull') = 0 Or Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno]') And c.[name] = 'Id' And Type_Name(c.system_type_id) = 'int')
	Alter Table [dbo].[Aluno] Alter Column [Id] int Not Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Nome' And [object_Id] = Object_Id('[dbo].[Aluno]'))
	Alter Table [dbo].[Aluno] Add [Nome] Varchar(255) Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno]') And c.[name] = 'Nome' And Type_Name(c.system_type_id) = 'varchar' And c.max_length = 255 And c.[precision] = 0 And c.scale = 0)
		Alter Table [dbo].[Aluno] Alter Column [Nome] Varchar(255) Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Usuario' And [object_Id] = Object_Id('[dbo].[Aluno]'))
	Alter Table [dbo].[Aluno] Add [Usuario] Varchar(45) Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno]') And c.[name] = 'Senha' And Type_Name(c.system_type_id) = 'varchar' And c.max_length = 45 And c.[precision] = 0 And c.scale = 0)
		Alter Table [dbo].[Aluno] Alter Column [Usuario] Varchar(45) Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Senha' And [object_Id] = Object_Id('[dbo].[Aluno]'))
	Alter Table [dbo].[Aluno] Add [Senha] Char(60) Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno]') And c.[name] = 'Senha' And Type_Name(c.system_type_id) = 'varchar' And c.max_length = 60 And c.[precision] = 0 And c.scale = 0)
		Alter Table [dbo].[Aluno] Alter Column [Senha] Char(60) Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'IsDeleted' And [object_Id] = Object_Id('[dbo].[Aluno]'))
	Alter Table [dbo].[Aluno] Add [IsDeleted] Bit Not Null Default 0
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno]') And c.[name] = 'IsDeleted' And Type_Name(c.system_type_id) = 'Bit' And c.max_length = 1)
		Begin
			Alter Table [dbo].[Aluno] Alter Column [IsDeleted] Bit NOT NULL
			Alter Table [dbo].[Aluno] Add  Default (0) For [IsDeleted]
		End
Go

If Not Exists(Select * From sys.key_constraints kc Where parent_object_id = Object_Id('[dbo].[Aluno]') And kc.[type] = 'PK')
	Alter Table [dbo].[Aluno] Add Constraint [Aluno_PK] Primary Key  ([Id])
Go