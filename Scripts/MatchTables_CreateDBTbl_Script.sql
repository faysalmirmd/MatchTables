-- Script for Creating Database and Tables for MatchTables assignment

IF Not EXISTS (SELECT name FROM master.sys.databases WHERE name = N'MatchTablesDB')
	CREATE DATABASE [MatchTablesDB]
GO

USE [MatchTablesDB]
GO

IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'EmployeeOldTable'))
BEGIN
    CREATE TABLE [dbo].[EmployeeOldTable](
	[socialsecuritynumber] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
		 CONSTRAINT [PK_EmployeeOldTable] PRIMARY KEY CLUSTERED 
		 (
			[socialsecuritynumber] ASC
		 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'EmployeeNewTable'))
BEGIN
    CREATE TABLE [dbo].[EmployeeNewTable](
	[socialsecuritynumber] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
		 CONSTRAINT [PK_EmployeeNewTable] PRIMARY KEY CLUSTERED 
		 (
			[socialsecuritynumber] ASC
		 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END


IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'EmployeeOldTable'))
BEGIN
    CREATE TABLE [dbo].[EmployeeOldTable](
	[socialsecuritynumber] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
		 CONSTRAINT [PK_EmployeeOldTable] PRIMARY KEY CLUSTERED 
		 (
			[socialsecuritynumber] ASC
		 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END


IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'StudentOldTable'))
BEGIN
	CREATE TABLE [dbo].[StudentOldTable](
		[StudentId] [nvarchar](50) NOT NULL,
		[Firstname] [nvarchar](50) NOT NULL,
		[Lastname] [nvarchar](50) NOT NULL,
		[Department] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_StudentOldTable] PRIMARY KEY CLUSTERED 
	(
		[StudentId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
End

IF (Not EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'StudentNewTable'))
BEGIN
	CREATE TABLE [dbo].[StudentNewTable](
		[StudentId] [nvarchar](50) NOT NULL,
		[Firstname] [nvarchar](50) NOT NULL,
		[Lastname] [nvarchar](50) NOT NULL,
		[Department] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_StudentNewTable] PRIMARY KEY CLUSTERED 
	(
		[StudentId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
End

