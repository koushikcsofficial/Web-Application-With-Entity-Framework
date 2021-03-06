USE [master]
GO
/****** Object:  Database [AnnonymousMessage]    Script Date: 03-04-2020 14:37:48 ******/
CREATE DATABASE [AnnonymousMessage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AnnonymousMessage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AnnonymousMessage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AnnonymousMessage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AnnonymousMessage_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AnnonymousMessage] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AnnonymousMessage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AnnonymousMessage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET ARITHABORT OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AnnonymousMessage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AnnonymousMessage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AnnonymousMessage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AnnonymousMessage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AnnonymousMessage] SET  MULTI_USER 
GO
ALTER DATABASE [AnnonymousMessage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AnnonymousMessage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AnnonymousMessage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AnnonymousMessage] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AnnonymousMessage] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AnnonymousMessage] SET QUERY_STORE = OFF
GO
USE [AnnonymousMessage]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 03-04-2020 14:37:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Message_Id] [int] IDENTITY(1,1) NOT NULL,
	[To_User] [varchar](250) NOT NULL,
	[From_User] [varchar](250) NOT NULL,
	[Message_Body] [text] NOT NULL,
	[Message_Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Message_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03-04-2020 14:37:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Role_Id] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Role_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03-04-2020 14:37:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](50) NOT NULL,
	[User_Email] [varchar](250) NOT NULL,
	[User_Password] [varchar](250) NOT NULL,
	[User_Role] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Message_Id], [To_User], [From_User], [Message_Body], [Message_Time]) VALUES (4, N'nhm@gmail.com', N'xaz@az.com', N'hello', CAST(N'2020-04-02T21:32:14.430' AS DateTime))
INSERT [dbo].[Messages] ([Message_Id], [To_User], [From_User], [Message_Body], [Message_Time]) VALUES (5, N'nhm@gmail.com', N'koushik.official1999@gmail.com', N'hello', CAST(N'2020-04-02T21:32:54.170' AS DateTime))
INSERT [dbo].[Messages] ([Message_Id], [To_User], [From_User], [Message_Body], [Message_Time]) VALUES (6, N'koushik.official1999@gmail.com', N'nhm@gmail.com', N'hello', CAST(N'2020-04-02T21:33:22.113' AS DateTime))
INSERT [dbo].[Messages] ([Message_Id], [To_User], [From_User], [Message_Body], [Message_Time]) VALUES (7, N'koushik.official1999@gmail.com', N'xaz@az.com', N'hello', CAST(N'2020-04-02T21:33:38.210' AS DateTime))
INSERT [dbo].[Messages] ([Message_Id], [To_User], [From_User], [Message_Body], [Message_Time]) VALUES (8, N'xaz@az.com', N'koushik.official1999@gmail.com', N'hello', CAST(N'2020-04-02T21:34:07.003' AS DateTime))
INSERT [dbo].[Messages] ([Message_Id], [To_User], [From_User], [Message_Body], [Message_Time]) VALUES (9, N'xaz@az.com', N'nhm@gmail.com', N'hello', CAST(N'2020-04-02T21:34:22.640' AS DateTime))
SET IDENTITY_INSERT [dbo].[Messages] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Role_Id], [Role_Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Role_Id], [Role_Name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([User_Id], [User_Name], [User_Email], [User_Password], [User_Role]) VALUES (4, N'KOUSHIK SAHA', N'koushik.official1999@gmail.com', N'123', 2)
INSERT [dbo].[Users] ([User_Id], [User_Name], [User_Email], [User_Password], [User_Role]) VALUES (5, N'Apalak', N'xaz@az.com', N'12345', 2)
INSERT [dbo].[Users] ([User_Id], [User_Name], [User_Email], [User_Password], [User_Role]) VALUES (6, N'Nadim', N'nhm@gmail.com', N'123456', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_From_User]  DEFAULT ('Annonymous') FOR [From_User]
GO
USE [master]
GO
ALTER DATABASE [AnnonymousMessage] SET  READ_WRITE 
GO
