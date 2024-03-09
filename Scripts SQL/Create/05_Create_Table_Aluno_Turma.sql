USE [DataBaseTeste]
GO

If Object_Id('[dbo].[Aluno_Turma]') Is Null
	Create Table [dbo].[Aluno_Turma] ([Id] int Not Null Identity(1,1))
Go

If Not ColumnProperty (Object_Id('[dbo].[Aluno_Turma]') , 'Id', 'AllowsNull') = 0 Or Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno_Turma]') And c.[name] = 'Id' And Type_Name(c.system_type_id) = 'int')
	Alter Table [dbo].[Aluno_Turma] Alter Column [Id] int Not Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Aluno_Id' And [object_Id] = Object_Id('[dbo].[Aluno_Turma]'))
	Alter Table [dbo].[Aluno_Turma] Add [Aluno_Id] Int Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno_Turma]') And c.[name] = 'Aluno_Id' And Type_Name(c.system_type_id) = 'int' And c.max_length = 4 And c.[precision] = 10 And c.scale = 0)
		Alter Table [dbo].[Aluno_Turma] Alter Column [Aluno_Id] int Null
Go

If Not Exists (Select * From sys.columns Where [name] = 'Turma_Id' And [object_Id] = Object_Id('[dbo].[Aluno_Turma]'))
	Alter Table [dbo].[Aluno_Turma] Add [Turma_Id] Int Null
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno_Turma]') And c.[name] = 'Turma_Id' And Type_Name(c.system_type_id) = 'int' And c.max_length = 4 And c.[precision] = 10 And c.scale = 0)
		Alter Table [dbo].[Aluno_Turma] Alter Column [Turma_Id] int Null
Go

If Not Exists(Select * From sys.key_constraints kc Where parent_object_id = Object_Id('[dbo].[Aluno_Turma]') And kc.[type] = 'PK')
	Alter Table [dbo].[Aluno_Turma] Add Constraint [Aluno_Turma_PK] Primary Key  ([Id])
Go

If Not Exists(Select * From sys.foreign_keys fk Where fk.parent_object_id = Object_Id('[dbo].[Aluno_Turma]') And fk.[name] = 'FK__Aluno_Turma__Aluno')
	Alter Table [dbo].[Aluno_Turma] Add Constraint [FK__Aluno_Turma__Aluno] Foreign Key ([Aluno_Id]) References [dbo].[Aluno] ([Id])
Go

If Not Exists(Select * From sys.foreign_keys fk Where fk.parent_object_id = Object_Id('[dbo].[Aluno_Turma]') And fk.[name] = 'FK__Aluno_Turma__Turma')
	Alter Table [dbo].[Aluno_Turma] Add Constraint [FK__Aluno_Turma__Turma] Foreign Key ([Turma_Id]) References [dbo].[Turma] ([Id])
Go