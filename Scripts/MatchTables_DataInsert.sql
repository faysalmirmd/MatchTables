--Sample Script to insert data into Tables for testing MatchTables
USE [MatchTablesDB]
GO

INSERT INTO [dbo].[EmployeeOldTable]
           ([socialsecuritynumber]
           ,[Firstname]
           ,[Lastname]
           ,[Department])

     VALUES ('01010101','Kari','Nordmann','Sales'),
            ('01010102','Jack','Jackson','Support'),
            ('01010103','Nils','Nilsen','Sales')
GO

INSERT INTO [dbo].[EmployeeNewTable]
           ([socialsecuritynumber]
           ,[Firstname]
           ,[Lastname]
           ,[Department])

     VALUES ('01010101','Kari','Nordman','Support'),
            ('0101004','Esther','Doe','Support'),
            ('01010103','Nils','Nilsen','Sales')
GO

INSERT INTO [dbo].[StudentOldTable]
           ([StudentId]
           ,[Firstname]
           ,[Lastname]
           ,[Department])

     VALUES ('01010101','John','Nordman','CSE'),
            ('01010102','Jack','Jackson','EEE'),
            ('01010103','Nils','Nilsen','ME'),
			('01010104','Nill','Mackenzie','ME'),
			('01010105','Trevor','James','ME'),
			('01010106','Donald','Nuth','ME')
GO

INSERT INTO [dbo].[StudentNewTable]
           ([StudentId]
           ,[Firstname]
           ,[Lastname]
           ,[Department])

     VALUES ('01010101','John','Nordman','CSE'),
            ('01010103','Nils','Nilsen','ME'),
			('01010104','Esther','Doe','EEE'),
			('01010105','Brad','Pitt','CSE'),
			('01010106','Donald','Nuth','EEE'),
			('01010107','Esther','Doe','EEE')

GO


