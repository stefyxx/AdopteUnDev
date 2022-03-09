USE [AdopteUnDev]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Review_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Review]'))
ALTER TABLE [dbo].[Review] DROP CONSTRAINT [FK_Review_Developer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg] DROP CONSTRAINT [FK_LangCateg_ITLang]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg] DROP CONSTRAINT [FK_LangCateg_Categories]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang] DROP CONSTRAINT [FK_DevLang_ITLang]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang] DROP CONSTRAINT [FK_DevLang_Developer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev] DROP CONSTRAINT [FK_ClientEndorseDev_Developer]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Client]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev] DROP CONSTRAINT [FK_ClientEndorseDev_Client]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Review_ReviewDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Review] DROP CONSTRAINT [DF_Review_ReviewDate]
END
GO
/****** Object:  Table [dbo].[Review]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Review]') AND type in (N'U'))
DROP TABLE [dbo].[Review]
GO
/****** Object:  Table [dbo].[LangCateg]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LangCateg]') AND type in (N'U'))
DROP TABLE [dbo].[LangCateg]
GO
/****** Object:  Table [dbo].[ITLang]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ITLang]') AND type in (N'U'))
DROP TABLE [dbo].[ITLang]
GO
/****** Object:  Table [dbo].[DevLang]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DevLang]') AND type in (N'U'))
DROP TABLE [dbo].[DevLang]
GO
/****** Object:  Table [dbo].[Developer]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Developer]') AND type in (N'U'))
DROP TABLE [dbo].[Developer]
GO
/****** Object:  Table [dbo].[ClientEndorseDev]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]') AND type in (N'U'))
DROP TABLE [dbo].[ClientEndorseDev]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
DROP TABLE [dbo].[Client]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 15-01-22 16:26:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO

USE [AdopteUnDev]
GO
/****** Object:  User [AdopteUser]    Script Date: 15-01-22 16:26:18 ******/
CREATE USER [AdopteUser] FOR LOGIN [AdopteUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [AdopteUser]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[idCategory] [int] NOT NULL,
	[CategLabel] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[idClient] [int] NOT NULL,
	[CliName] [nvarchar](50) NOT NULL,
	[CliFirstName] [nvarchar](50) NOT NULL,
	[CliMail] [nvarchar](250) NOT NULL,
	[CliCompany] [nvarchar](50) NOT NULL,
	[CliLogin] [nvarchar](50) NULL,
	[CliPassword] [nvarchar](250) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientEndorseDev]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientEndorseDev](
	[idClient] [int] NOT NULL,
	[idDev] [int] NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[EndorseNumber] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ClientEndorseDev] PRIMARY KEY CLUSTERED 
(
	[EndorseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Developer]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Developer](
	[idDev] [int] NOT NULL,
	[DevName] [nvarchar](50) NOT NULL,
	[DevFirstName] [nvarchar](50) NOT NULL,
	[DevBirthDate] [datetime] NOT NULL,
	[DevPicture] [nvarchar](50) NULL,
	[DevHourCost] [float] NOT NULL,
	[DevDayCost] [float] NOT NULL,
	[DevMonthCost] [float] NOT NULL,
	[DevMail] [nvarchar](250) NOT NULL,
	[DevCategPrincipal] [nvarchar](250) NULL,
 CONSTRAINT [PK_Developer] PRIMARY KEY CLUSTERED 
(
	[idDev] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevLang]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevLang](
	[idDev] [int] NOT NULL,
	[idIT] [int] NOT NULL,
	[Since] [datetime] NULL,
 CONSTRAINT [PK_DevLang] PRIMARY KEY CLUSTERED 
(
	[idDev] ASC,
	[idIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ITLang]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITLang](
	[idIT] [int] NOT NULL,
	[ITLabel] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ITLang] PRIMARY KEY CLUSTERED 
(
	[idIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LangCateg]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LangCateg](
	[idIT] [int] NOT NULL,
	[idCategory] [int] NOT NULL,
 CONSTRAINT [PK_LangCateg] PRIMARY KEY CLUSTERED 
(
	[idIT] ASC,
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 15-01-22 16:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[idReview] [int] IDENTITY(1,1) NOT NULL,
	[ReviewName] [nvarchar](50) NOT NULL,
	[ReviewText] [nvarchar](max) NOT NULL,
	[ReviewMail] [nvarchar](256) NOT NULL,
	[ReviewDate] [datetime] NOT NULL,
	[idDev] [int] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[idReview] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (1, N'WEB')
GO
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (2, N'ANALYSE')
GO
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (3, N'WEBAPP')
GO
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (4, N'GEEK')
GO
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (5, N'WPF')
GO
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (6, N'Incrédules')
GO
INSERT [dbo].[Developer] ([idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal]) VALUES (1, N'Person', N'Mike', CAST(N'1982-03-17T00:00:00.000' AS DateTime), N'avatar.png', 65, 560, 2000, N'michael.person@cognitic.be', N'1')
GO
INSERT [dbo].[Developer] ([idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal]) VALUES (2, N'Mononoke', N'San', CAST(N'2000-01-12T00:00:00.000' AS DateTime), N'mononoke.jpg', 45, 450, 1500, N'san.mononoke@ghibli.jp', N'2')
GO
INSERT [dbo].[Developer] ([idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal]) VALUES (3, N'Sorcer', N'Yababa', CAST(N'1880-01-01T00:00:00.000' AS DateTime), N'yubaba.jpg', 10, 150, 1000, N'Sorcer.yubaba@ghibli.jp', N'3')
GO
INSERT [dbo].[Developer] ([idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal]) VALUES (4, N'Dame', N'Eboshi', CAST(N'1945-02-02T00:00:00.000' AS DateTime), N'Eboshi.jpg', 25, 250, 1800, N'dame.Eboshi@ghibli.jp', N'4')
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (1, 1, CAST(N'2000-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (2, 1, CAST(N'1990-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (2, 2, NULL)
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (2, 4, NULL)
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (3, 1, NULL)
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (3, 4, NULL)
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (4, 3, NULL)
GO
INSERT [dbo].[DevLang] ([idDev], [idIT], [Since]) VALUES (4, 4, NULL)
GO
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (1, N'C#')
GO
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (2, N'ASP MVC')
GO
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (3, N'JAVA')
GO
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (4, N'UML')
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (1, 1)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (1, 4)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (1, 5)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (1, 6)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (2, 1)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (2, 3)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (3, 1)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (3, 4)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (3, 5)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (3, 6)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (4, 2)
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (4, 4)
GO
ALTER TABLE [dbo].[Review] ADD  CONSTRAINT [DF_Review_ReviewDate]  DEFAULT (getdate()) FOR [ReviewDate]
GO
ALTER TABLE [dbo].[ClientEndorseDev]  WITH CHECK ADD  CONSTRAINT [FK_ClientEndorseDev_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
GO
ALTER TABLE [dbo].[ClientEndorseDev] CHECK CONSTRAINT [FK_ClientEndorseDev_Client]
GO
ALTER TABLE [dbo].[ClientEndorseDev]  WITH CHECK ADD  CONSTRAINT [FK_ClientEndorseDev_Developer] FOREIGN KEY([idDev])
REFERENCES [dbo].[Developer] ([idDev])
GO
ALTER TABLE [dbo].[ClientEndorseDev] CHECK CONSTRAINT [FK_ClientEndorseDev_Developer]
GO
ALTER TABLE [dbo].[DevLang]  WITH CHECK ADD  CONSTRAINT [FK_DevLang_Developer] FOREIGN KEY([idDev])
REFERENCES [dbo].[Developer] ([idDev])
GO
ALTER TABLE [dbo].[DevLang] CHECK CONSTRAINT [FK_DevLang_Developer]
GO
ALTER TABLE [dbo].[DevLang]  WITH CHECK ADD  CONSTRAINT [FK_DevLang_ITLang] FOREIGN KEY([idIT])
REFERENCES [dbo].[ITLang] ([idIT])
GO
ALTER TABLE [dbo].[DevLang] CHECK CONSTRAINT [FK_DevLang_ITLang]
GO
ALTER TABLE [dbo].[LangCateg]  WITH CHECK ADD  CONSTRAINT [FK_LangCateg_Categories] FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([idCategory])
GO
ALTER TABLE [dbo].[LangCateg] CHECK CONSTRAINT [FK_LangCateg_Categories]
GO
ALTER TABLE [dbo].[LangCateg]  WITH CHECK ADD  CONSTRAINT [FK_LangCateg_ITLang] FOREIGN KEY([idIT])
REFERENCES [dbo].[ITLang] ([idIT])
GO
ALTER TABLE [dbo].[LangCateg] CHECK CONSTRAINT [FK_LangCateg_ITLang]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Developer] FOREIGN KEY([idDev])
REFERENCES [dbo].[Developer] ([idDev])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Developer]
GO
USE [master]
GO
ALTER DATABASE [AdopteUnDev] SET  READ_WRITE 
GO
