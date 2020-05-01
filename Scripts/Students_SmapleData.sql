--Sample Script to create Tables for testing MatchTables

CREATE TABLE [dbo].[OldStudent](
	[StudentId] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OldStudent] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NewStudent](
	[StudentId] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NewStudent] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[OldStudent]
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

INSERT INTO [dbo].[NewStudent]
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


