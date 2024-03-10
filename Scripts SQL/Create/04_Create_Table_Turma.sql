USE [DataBaseTeste]
GO

If Object_Id('[dbo].[Turma]') Is Null
	Create Table [dbo].[Turma] ([Id] int Not Null Identity(1,1))
Go

If Not ColumnProperty (Object_Id('[dbo].[Turma]') , 'Id', 'AllowsNull') = 0 Or Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Turma]') And c.[name] = 'Id' And Type_Name(c.system_type_id) = 'int')
	Alter Table [dbo].[Turma] Alter Column [Id] int Not Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Curso_Id' And [object_Id] = Object_Id('[dbo].[Turma]'))
	Alter Table [dbo].[Turma] Add [Curso_Id] Int Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Turma]') And c.[name] = 'Curso_Id' And Type_Name(c.system_type_id) = 'int' And c.max_length = 4 And c.[precision] = 10 And c.scale = 0)
		Alter Table [dbo].[Turma] Alter Column [Curso_Id] int Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Turma' And [object_Id] = Object_Id('[dbo].[Turma]'))
	Alter Table [dbo].[Turma] Add [Turma] Varchar(45) Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Turma]') And c.[name] = 'Turma' And Type_Name(c.system_type_id) = 'varchar' And c.max_length = 45 And c.[precision] = 0 And c.scale = 0)
		Alter Table [dbo].[Turma] Alter Column [Turma] Varchar(45) Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Ano' And [object_Id] = Object_Id('[dbo].[Turma]'))
	Alter Table [dbo].[Turma] Add [Ano] Int Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Turma]') And c.[name] = 'Ano' And Type_Name(c.system_type_id) = 'int' And c.max_length = 4 And c.[precision] = 10 And c.scale = 0)
		Alter Table [dbo].[Turma] Alter Column [Ano] Int Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'IsDeleted' And [object_Id] = Object_Id('[dbo].[Turma]'))
	Alter Table [dbo].[Turma] Add [IsDeleted] Bit Not Null Default 0
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Turma]') And c.[name] = 'IsDeleted' And Type_Name(c.system_type_id) = 'Bit' And c.max_length = 1)
		Begin
			Alter Table [dbo].[Turma] Alter Column [IsDeleted] Bit NOT NULL
			Alter Table [dbo].[Turma] Add  Default (0) For [IsDeleted]
		End
Go

If Not Exists(Select * From sys.key_constraints kc Where parent_object_id = Object_Id('[dbo].[Turma]') And kc.[type] = 'PK')
	Alter Table [dbo].[Turma] Add Constraint [Turma_PK] Primary Key  ([Id])
Go

If Not Exists(Select * From sys.foreign_keys fk Where fk.parent_object_id = Object_Id('[dbo].[Turma]') And fk.[name] = 'FK__Turma__Curso')
	Alter Table [dbo].[Turma] Add Constraint [FK__Turma__Curso] Foreign Key ([Curso_Id]) References [dbo].[Curso] ([Id])
Go