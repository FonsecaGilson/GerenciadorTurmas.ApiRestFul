USE [DataBaseTeste]
GO

If Object_Id('[dbo].[Curso]') Is Null
	Create Table [dbo].[Curso] ([Id] int Not Null Identity(1,1))
Go

If Not ColumnProperty (Object_Id('[dbo].[Curso]') , 'Id', 'AllowsNull') = 0 Or Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Curso]') And c.[name] = 'Id' And Type_Name(c.system_type_id) = 'int')
	Alter Table [dbo].[Curso] Alter Column [Id] int Not Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Curso' And [object_Id] = Object_Id('[dbo].[Curso]'))
	Alter Table [dbo].[Curso] Add [Curso] Varchar(255) Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Curso]') And c.[name] = 'Nome' And Type_Name(c.system_type_id) = 'varchar' And c.max_length = 255 And c.[precision] = 0 And c.scale = 0)
		Alter Table [dbo].[Curso] Alter Column [Curso] Varchar(255) Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'IsDeleted' And [object_Id] = Object_Id('[dbo].[Curso]'))
	Alter Table [dbo].[Curso] Add [IsDeleted] Bit Not Null Default 0
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Curso]') And c.[name] = 'IsDeleted' And Type_Name(c.system_type_id) = 'Bit' And c.max_length = 1)
		Begin
			Alter Table [dbo].[Curso] Alter Column [IsDeleted] Bit NOT NULL
			Alter Table [dbo].[Curso] Add  Default (0) For [IsDeleted]
		End
Go

If Not Exists(Select * From sys.key_constraints kc Where parent_object_id = Object_Id('[dbo].[Curso]') And kc.[type] = 'PK')
	Alter Table [dbo].[Curso] Add Constraint [Curso_PK] Primary Key  ([Id])
Go