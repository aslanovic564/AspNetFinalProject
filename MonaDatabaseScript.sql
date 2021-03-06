/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [MonaDataBase]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE DATABASE [MonaDataBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MonaDataBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MonaDataBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MonaDataBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MonaDataBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MonaDataBase] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MonaDataBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MonaDataBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MonaDataBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MonaDataBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MonaDataBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MonaDataBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [MonaDataBase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MonaDataBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MonaDataBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MonaDataBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MonaDataBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MonaDataBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MonaDataBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MonaDataBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MonaDataBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MonaDataBase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MonaDataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MonaDataBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MonaDataBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MonaDataBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MonaDataBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MonaDataBase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MonaDataBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MonaDataBase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MonaDataBase] SET  MULTI_USER 
GO
ALTER DATABASE [MonaDataBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MonaDataBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MonaDataBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MonaDataBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MonaDataBase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MonaDataBase] SET QUERY_STORE = OFF
GO
USE [MonaDataBase]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MonaDataBase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CastingModels]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CastingModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CastHeader] [nvarchar](100) NULL,
	[CastResumeHeader] [nvarchar](500) NULL,
	[ImageContentId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CastingModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientsFedbackModels]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientsFedbackModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](max) NULL,
	[ClientStatus] [nvarchar](max) NULL,
	[Descriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.ClientsFedbackModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactDetalis]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDetalis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactDetaliss] [nvarchar](200) NOT NULL,
	[Reception] [nvarchar](max) NULL,
	[Booking] [nvarchar](max) NULL,
	[President] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ContactDetalis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUserModels]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUserModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[UserEmail] [nvarchar](30) NOT NULL,
	[UserResume] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.ContactUserModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomePageChanges]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HomePageChanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Facebook] [nvarchar](max) NULL,
	[Tviter] [nvarchar](max) NULL,
	[Pinterest] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[Youtube] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HomePageChanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageContents]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrlName] [nvarchar](max) NULL,
	[MonaTeamModelId] [int] NOT NULL,
	[LatestNewsContentId] [int] NOT NULL,
	[ClientsFedbackModelsId] [int] NOT NULL,
	[ModellsChangeId] [int] NOT NULL,
	[HomePageChangeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ImageContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LatestNewsContents]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LatestNewsContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewsImageUrl] [nvarchar](max) NULL,
	[ImageDescription] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[HomePageChange_Id] [int] NULL,
 CONSTRAINT [PK_dbo.LatestNewsContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModelCategories]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.ModelCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModellsChanges]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModellsChanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelFullName] [nvarchar](max) NULL,
	[FigurStatus] [nvarchar](max) NULL,
	[ModelCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ModellsChanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonaTeamModels]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonaTeamModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamImagesDescription] [nvarchar](max) NOT NULL,
	[NameTeam] [nvarchar](max) NOT NULL,
	[statusTeam] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.MonaTeamModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socials]    Script Date: 1/29/2019 5:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Facebook] [nvarchar](max) NULL,
	[Tviter] [nvarchar](max) NULL,
	[Pinterest] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[Youtube] [nvarchar](max) NULL,
	[ModellsChangeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Socials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageContentId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_ImageContentId] ON [dbo].[CastingModels]
(
	[ImageContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientsFedbackModelsId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClientsFedbackModelsId] ON [dbo].[ImageContents]
(
	[ClientsFedbackModelsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HomePageChangeId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_HomePageChangeId] ON [dbo].[ImageContents]
(
	[HomePageChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LatestNewsContentId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_LatestNewsContentId] ON [dbo].[ImageContents]
(
	[LatestNewsContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ModellsChangeId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_ModellsChangeId] ON [dbo].[ImageContents]
(
	[ModellsChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MonaTeamModelId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_MonaTeamModelId] ON [dbo].[ImageContents]
(
	[MonaTeamModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HomePageChange_Id]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_HomePageChange_Id] ON [dbo].[LatestNewsContents]
(
	[HomePageChange_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ModelCategoryId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_ModelCategoryId] ON [dbo].[ModellsChanges]
(
	[ModelCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ModellsChangeId]    Script Date: 1/29/2019 5:59:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_ModellsChangeId] ON [dbo].[Socials]
(
	[ModellsChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CastingModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CastingModels_dbo.ImageContents_ImageContentId] FOREIGN KEY([ImageContentId])
REFERENCES [dbo].[ImageContents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CastingModels] CHECK CONSTRAINT [FK_dbo.CastingModels_dbo.ImageContents_ImageContentId]
GO
ALTER TABLE [dbo].[ImageContents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageContents_dbo.ClientsFedbackModels_ClientsFedbackModelsId] FOREIGN KEY([ClientsFedbackModelsId])
REFERENCES [dbo].[ClientsFedbackModels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageContents] CHECK CONSTRAINT [FK_dbo.ImageContents_dbo.ClientsFedbackModels_ClientsFedbackModelsId]
GO
ALTER TABLE [dbo].[ImageContents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageContents_dbo.HomePageChanges_HomePageChangeId] FOREIGN KEY([HomePageChangeId])
REFERENCES [dbo].[HomePageChanges] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageContents] CHECK CONSTRAINT [FK_dbo.ImageContents_dbo.HomePageChanges_HomePageChangeId]
GO
ALTER TABLE [dbo].[ImageContents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageContents_dbo.LatestNewsContents_LatestNewsContentId] FOREIGN KEY([LatestNewsContentId])
REFERENCES [dbo].[LatestNewsContents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageContents] CHECK CONSTRAINT [FK_dbo.ImageContents_dbo.LatestNewsContents_LatestNewsContentId]
GO
ALTER TABLE [dbo].[ImageContents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageContents_dbo.ModellsChanges_ModellsChangeId] FOREIGN KEY([ModellsChangeId])
REFERENCES [dbo].[ModellsChanges] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageContents] CHECK CONSTRAINT [FK_dbo.ImageContents_dbo.ModellsChanges_ModellsChangeId]
GO
ALTER TABLE [dbo].[ImageContents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageContents_dbo.MonaTeamModels_MonaTeamModelId] FOREIGN KEY([MonaTeamModelId])
REFERENCES [dbo].[MonaTeamModels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageContents] CHECK CONSTRAINT [FK_dbo.ImageContents_dbo.MonaTeamModels_MonaTeamModelId]
GO
ALTER TABLE [dbo].[LatestNewsContents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LatestNewsContents_dbo.HomePageChanges_HomePageChange_Id] FOREIGN KEY([HomePageChange_Id])
REFERENCES [dbo].[HomePageChanges] ([Id])
GO
ALTER TABLE [dbo].[LatestNewsContents] CHECK CONSTRAINT [FK_dbo.LatestNewsContents_dbo.HomePageChanges_HomePageChange_Id]
GO
ALTER TABLE [dbo].[ModellsChanges]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModellsChanges_dbo.ModelCategories_ModelCategoryId] FOREIGN KEY([ModelCategoryId])
REFERENCES [dbo].[ModelCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModellsChanges] CHECK CONSTRAINT [FK_dbo.ModellsChanges_dbo.ModelCategories_ModelCategoryId]
GO
ALTER TABLE [dbo].[Socials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Socials_dbo.ModellsChanges_ModellsChangeId] FOREIGN KEY([ModellsChangeId])
REFERENCES [dbo].[ModellsChanges] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Socials] CHECK CONSTRAINT [FK_dbo.Socials_dbo.ModellsChanges_ModellsChangeId]
GO
USE [master]
GO
ALTER DATABASE [MonaDataBase] SET  READ_WRITE 
GO
