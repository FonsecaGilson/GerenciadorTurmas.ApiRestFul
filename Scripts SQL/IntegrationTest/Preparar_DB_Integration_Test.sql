USE [DataBaseTeste]
GO

-- Drop Aluno_Turma, Aluno, Turma

If Object_Id('[dbo].[Aluno_Turma]') Is Not Null
	Drop Table [dbo].[Aluno_Turma]

If Object_Id('[dbo].[Aluno]') Is Not Null
	Drop Table [dbo].[Aluno]

If Object_Id('[dbo].[Turma]') Is Not Null
	Drop Table [dbo].[Turma]

-- Create Aluno
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


-- Create Turma
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


-- Create Aluno_Turma
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

If Not Exists (Select * From sys.columns Where [name] = 'IsDeleted' And [object_Id] = Object_Id('[dbo].[Aluno_Turma]'))
	Alter Table [dbo].[Aluno_Turma] Add [IsDeleted] Bit Not Null Default 0
Else 
	If Not Exists(Select * From sys.columns c Where c.[object_id] = Object_Id('[dbo].[Aluno_Turma]') And c.[name] = 'IsDeleted' And Type_Name(c.system_type_id) = 'Bit' And c.max_length = 1)
		Begin
			Alter Table [dbo].[Aluno_Turma] Alter Column [IsDeleted] Bit NOT NULL
			Alter Table [dbo].[Aluno_Turma] Add  Default (0) For [IsDeleted]
		End
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

-- Popular tabelas para teste de integração
 
 Declare 
	@Aluno_Id Int = Null,
	@Turma_Id Int = Null


Insert Into Aluno ( Nome, Usuario, Senha )
Values ( 'Maria Helena', 'Mariahel', '$2a$12$L2HFlh2joniJopqoipKnCeylABHhgi4xZ7j64pCkeEzghdqnenh06' )

Select @Aluno_Id = Scope_Identity()

Insert Into Turma ( Turma, Ano )
Values ( 'Matematica', 2024 )

Select @Turma_Id = Scope_Identity()

Insert Into Aluno_Turma ( Aluno_Id, Turma_Id )
Values ( @Aluno_Id, @Turma_Id )

Insert Into Aluno ( Nome, Usuario, Senha )
Values ( 'João Paulo', 'JPaulo', '$2a$12$L2HFlh2joniJopqoipKnCeylABHhgi4xZ7j64pCkeEzghdqnenh06' )

Select @Aluno_Id = Scope_Identity()

Insert Into Turma ( Turma, Ano )
Values ( 'Fisica', 2024 )

Select @Turma_Id = Scope_Identity()

Insert Into Aluno_Turma ( Aluno_Id, Turma_Id )
Values ( @Aluno_Id, @Turma_Id )

Insert Into Aluno ( Nome, Usuario, Senha )
Values ( 'Bruno Serafim', 'Brfim', '$2a$12$L2HFlh2joniJopqoipKnCeylABHhgi4xZ7j64pCkeEzghdqnenh06' )

Insert Into Turma ( Turma, Ano )
Values ( 'Economia', 2024 )

Insert Into Turma ( Turma, Ano )
Values ( 'Calculo I', 2024 )

                            