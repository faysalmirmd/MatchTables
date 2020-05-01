--Sample Script to create Tables for testing MatchTables

CREATE TABLE [dbo].[OldTable](
	[socialsecuritynumber] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OldTable] PRIMARY KEY CLUSTERED 
(
	[socialsecuritynumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NewTable](
	[socialsecuritynumber] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NewTable] PRIMARY KEY CLUSTERED 
(
	[socialsecuritynumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[OldTable]
           ([socialsecuritynumber]
           ,[Firstname]
           ,[Lastname]
           ,[Department])

     VALUES ('01010101','Kari','Nordmann','Sales'),
            ('01010102','Jack','Jackson','Support'),
            ('01010103','Nils','Nilsen','Sales')
GO

INSERT INTO [dbo].[NewTable]
           ([socialsecuritynumber]
           ,[Firstname]
           ,[Lastname]
           ,[Department])

     VALUES ('01010101','Kari','Nordman','Support'),
            ('0101004','Esther','Doe','Support'),
            ('01010103','Nils','Nilsen','Sales')
GO


