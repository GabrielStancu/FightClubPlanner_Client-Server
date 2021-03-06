USE [master]
GO
/****** Object:  Database [FightClubDb]    Script Date: 4/17/2021 1:50:29 PM ******/
CREATE DATABASE [FightClubDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FightClubDb', FILENAME = N'D:\Program Files\SQL Server Management Studio 2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\FightClubDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FightClubDb_log', FILENAME = N'D:\Program Files\SQL Server Management Studio 2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\FightClubDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FightClubDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FightClubDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FightClubDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FightClubDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FightClubDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FightClubDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FightClubDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [FightClubDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FightClubDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FightClubDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FightClubDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FightClubDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FightClubDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FightClubDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FightClubDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FightClubDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FightClubDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FightClubDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FightClubDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FightClubDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FightClubDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FightClubDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FightClubDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FightClubDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FightClubDb] SET RECOVERY FULL 
GO
ALTER DATABASE [FightClubDb] SET  MULTI_USER 
GO
ALTER DATABASE [FightClubDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FightClubDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FightClubDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FightClubDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FightClubDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FightClubDb', N'ON'
GO
ALTER DATABASE [FightClubDb] SET QUERY_STORE = OFF
GO
USE [FightClubDb]
GO
/****** Object:  User [abstract]    Script Date: 4/17/2021 1:50:29 PM ******/
CREATE USER [abstract] FOR LOGIN [abstract] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [abstract]
GO
/****** Object:  Schema [FightClubDbSchema]    Script Date: 4/17/2021 1:50:30 PM ******/
CREATE SCHEMA [FightClubDbSchema]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CovidTest]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CovidTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsPositive] [bit] NULL,
	[TestDate] [datetime] NULL,
	[FighterId] [int] NULL,
	[IsolationBubbleId] [int] NULL,
 CONSTRAINT [PK_CovidTests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fight]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fight](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FighterId1] [int] NULL,
	[FighterId2] [int] NULL,
	[TournamentId] [int] NULL,
	[FightTime] [datetime] NULL,
	[WinnerId] [int] NULL,
 CONSTRAINT [PK_Fights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fighter]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fighter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[Birthday] [datetime] NULL,
	[Weight] [int] NULL,
	[Height] [int] NULL,
 CONSTRAINT [PK_Fighters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invite]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invite](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FighterId] [int] NULL,
	[TournamentId] [int] NULL,
	[DateSent] [datetime] NULL,
	[InviteState] [int] NULL,
 CONSTRAINT [PK_Invites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IsolationBubble]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IsolationBubble](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
 CONSTRAINT [PK_IsolationBubbles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournament]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournament](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[OrganizerId] [int] NULL,
	[StartDate] [datetime] NULL,
 CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TournamentFighter]    Script Date: 4/17/2021 1:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TournamentFighter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TournamentId] [int] NULL,
	[FighterId] [int] NULL,
 CONSTRAINT [PK_TournamentFighters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CovidTest] ON 

INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1159, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 45, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1160, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 45, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1161, 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 45, 3)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1162, 0, CAST(N'2021-04-17T00:00:00.000' AS DateTime), 45, 2)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1163, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 44, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1164, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 44, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1165, 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 44, 3)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1166, 0, CAST(N'2021-04-17T00:00:00.000' AS DateTime), 44, 2)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1167, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 46, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1168, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 46, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1169, 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 46, 3)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1170, 0, CAST(N'2021-04-17T00:00:00.000' AS DateTime), 46, 2)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1171, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 48, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1172, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 48, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1173, 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 48, 3)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1174, 0, CAST(N'2021-04-17T00:00:00.000' AS DateTime), 48, 2)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1175, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 47, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1176, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 47, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1177, 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 47, 3)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1179, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 49, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1180, 0, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 49, 1)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1181, 0, CAST(N'2021-04-10T00:00:00.000' AS DateTime), 49, 3)
INSERT [dbo].[CovidTest] ([Id], [IsPositive], [TestDate], [FighterId], [IsolationBubbleId]) VALUES (1182, 1, CAST(N'2021-04-17T00:00:00.000' AS DateTime), 49, 2)
SET IDENTITY_INSERT [dbo].[CovidTest] OFF
GO
SET IDENTITY_INSERT [dbo].[Fight] ON 

INSERT [dbo].[Fight] ([Id], [FighterId1], [FighterId2], [TournamentId], [FightTime], [WinnerId]) VALUES (1161, 45, 48, 18, CAST(N'2021-04-08T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Fight] ([Id], [FighterId1], [FighterId2], [TournamentId], [FightTime], [WinnerId]) VALUES (1162, 44, 46, 18, CAST(N'2021-04-11T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Fight] ([Id], [FighterId1], [FighterId2], [TournamentId], [FightTime], [WinnerId]) VALUES (1163, 44, 48, 18, CAST(N'2021-04-14T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Fight] ([Id], [FighterId1], [FighterId2], [TournamentId], [FightTime], [WinnerId]) VALUES (1164, 44, 45, 18, CAST(N'2021-04-17T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Fight] OFF
GO
SET IDENTITY_INSERT [dbo].[Fighter] ON 

INSERT [dbo].[Fighter] ([Id], [FirstName], [LastName], [Username], [Password], [Birthday], [Weight], [Height]) VALUES (44, N'Adrian', N'Buciuman', N'AdiB', N'adi', CAST(N'1999-02-10T00:00:00.000' AS DateTime), 70, 178)
INSERT [dbo].[Fighter] ([Id], [FirstName], [LastName], [Username], [Password], [Birthday], [Weight], [Height]) VALUES (45, N'Daniel', N'Bancos', N'DaniB', N'dani', CAST(N'2000-07-05T00:00:00.000' AS DateTime), 80, 185)
INSERT [dbo].[Fighter] ([Id], [FirstName], [LastName], [Username], [Password], [Birthday], [Weight], [Height]) VALUES (46, N'Robert', N'Calatoae', N'RobiC', N'robi', CAST(N'1999-09-29T00:00:00.000' AS DateTime), 74, 170)
INSERT [dbo].[Fighter] ([Id], [FirstName], [LastName], [Username], [Password], [Birthday], [Weight], [Height]) VALUES (47, N'Dan', N'Anghel', N'DanA', N'dan', CAST(N'1999-06-14T00:00:00.000' AS DateTime), 68, 175)
INSERT [dbo].[Fighter] ([Id], [FirstName], [LastName], [Username], [Password], [Birthday], [Weight], [Height]) VALUES (48, N'Tudor', N'Pop', N'TudorP', N'tudor', CAST(N'1999-11-10T00:00:00.000' AS DateTime), 84, 180)
INSERT [dbo].[Fighter] ([Id], [FirstName], [LastName], [Username], [Password], [Birthday], [Weight], [Height]) VALUES (49, N'Andrei', N'Stirbu', N'AndreiS', N'andrei', CAST(N'1999-11-18T00:00:00.000' AS DateTime), 72, 178)
SET IDENTITY_INSERT [dbo].[Fighter] OFF
GO
SET IDENTITY_INSERT [dbo].[Invite] ON 

INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1050, 44, 18, CAST(N'2021-04-17T10:21:57.927' AS DateTime), 1)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1051, 45, 18, CAST(N'2021-04-17T10:22:00.423' AS DateTime), 1)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1052, 47, 18, CAST(N'2021-04-17T10:22:02.520' AS DateTime), 1)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1053, 46, 18, CAST(N'2021-04-17T10:22:03.807' AS DateTime), 1)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1054, 48, 18, CAST(N'2021-04-17T10:22:05.327' AS DateTime), 1)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1055, 49, 18, CAST(N'2021-04-17T10:22:06.830' AS DateTime), 1)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1056, 45, 17, CAST(N'2021-04-17T10:41:24.330' AS DateTime), 0)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1057, 45, 15, CAST(N'2021-04-17T10:41:31.070' AS DateTime), 0)
INSERT [dbo].[Invite] ([Id], [FighterId], [TournamentId], [DateSent], [InviteState]) VALUES (1058, 44, 17, CAST(N'2021-04-17T10:41:52.903' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Invite] OFF
GO
SET IDENTITY_INSERT [dbo].[IsolationBubble] ON 

INSERT [dbo].[IsolationBubble] ([Id], [Name]) VALUES (1, N'Cluj - Napoca')
INSERT [dbo].[IsolationBubble] ([Id], [Name]) VALUES (2, N'Orastie')
INSERT [dbo].[IsolationBubble] ([Id], [Name]) VALUES (3, N'Timisoara')
SET IDENTITY_INSERT [dbo].[IsolationBubble] OFF
GO
SET IDENTITY_INSERT [dbo].[Manager] ON 

INSERT [dbo].[Manager] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (5, N'Gabriel', N'Stancu', N'GabrielS', N'gabi')
INSERT [dbo].[Manager] ([Id], [FirstName], [LastName], [Username], [Password]) VALUES (6, N'Mircea', N'Tantau', N'MirceaT', N'mircea')
SET IDENTITY_INSERT [dbo].[Manager] OFF
GO
SET IDENTITY_INSERT [dbo].[Tournament] ON 

INSERT [dbo].[Tournament] ([Id], [Name], [Location], [OrganizerId], [StartDate]) VALUES (15, N'UFC Orastie', N'Orastie', 5, CAST(N'2021-04-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Tournament] ([Id], [Name], [Location], [OrganizerId], [StartDate]) VALUES (17, N'MMA Cluj-Napoca', N'Cluj-Napoca', 5, CAST(N'2021-04-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Tournament] ([Id], [Name], [Location], [OrganizerId], [StartDate]) VALUES (18, N'UFC Cluj-Napoca', N'Cluj-Napoca', 5, CAST(N'2021-04-17T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tournament] OFF
GO
SET IDENTITY_INSERT [dbo].[TournamentFighter] ON 

INSERT [dbo].[TournamentFighter] ([Id], [TournamentId], [FighterId]) VALUES (1039, 18, 44)
INSERT [dbo].[TournamentFighter] ([Id], [TournamentId], [FighterId]) VALUES (1040, 18, 45)
INSERT [dbo].[TournamentFighter] ([Id], [TournamentId], [FighterId]) VALUES (1041, 18, 47)
INSERT [dbo].[TournamentFighter] ([Id], [TournamentId], [FighterId]) VALUES (1042, 18, 49)
INSERT [dbo].[TournamentFighter] ([Id], [TournamentId], [FighterId]) VALUES (1043, 18, 48)
INSERT [dbo].[TournamentFighter] ([Id], [TournamentId], [FighterId]) VALUES (1044, 18, 46)
SET IDENTITY_INSERT [dbo].[TournamentFighter] OFF
GO
USE [master]
GO
ALTER DATABASE [FightClubDb] SET  READ_WRITE 
GO
