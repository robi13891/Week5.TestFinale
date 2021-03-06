USE [master]
GO
/****** Object:  Database [GestioneSpese]    Script Date: 08/10/2021 14:52:50 ******/
CREATE DATABASE [GestioneSpese]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestioneSpese', FILENAME = N'C:\Users\roberta.beretta\GestioneSpese.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestioneSpese_log', FILENAME = N'C:\Users\roberta.beretta\GestioneSpese_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GestioneSpese] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestioneSpese].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestioneSpese] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestioneSpese] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestioneSpese] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestioneSpese] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestioneSpese] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestioneSpese] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestioneSpese] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestioneSpese] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestioneSpese] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestioneSpese] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestioneSpese] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestioneSpese] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestioneSpese] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestioneSpese] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestioneSpese] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestioneSpese] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestioneSpese] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestioneSpese] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestioneSpese] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestioneSpese] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GestioneSpese] SET  MULTI_USER 
GO
ALTER DATABASE [GestioneSpese] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestioneSpese] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestioneSpese] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestioneSpese] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestioneSpese] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestioneSpese] SET QUERY_STORE = OFF
GO
USE [GestioneSpese]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [GestioneSpese]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/10/2021 14:52:51 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 08/10/2021 14:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spesa]    Script Date: 08/10/2021 14:52:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spesa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Descrizione] [nvarchar](500) NOT NULL,
	[Utente] [nvarchar](100) NOT NULL,
	[Importo] [decimal](18, 2) NOT NULL,
	[Approvato] [bit] NOT NULL,
 CONSTRAINT [PK_Spesa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211008091743_FirstMigration', N'5.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211008124856_SecondMigration', N'5.0.10')
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (1, N'Alloggio')
INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (2, N'Alimentari')
INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (3, N'Mediche')
INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (4, N'Attrezzatura')
INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (5, N'Altro')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Spesa] ON 

INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (1, CAST(N'2021-10-08T00:00:00.0000000' AS DateTime2), 1, N'due notti hotel oceano a Milano', N'roberta beretta', CAST(120.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (2, CAST(N'2021-09-11T00:00:00.0000000' AS DateTime2), 2, N'pranzo ristorante monti - roma', N'roberta beretta', CAST(32.50 AS Decimal(18, 2)), 0)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (3, CAST(N'2021-09-30T00:00:00.0000000' AS DateTime2), 1, N'tre notti hotel miramare riccione', N'mario bianchi', CAST(300.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (4, CAST(N'2021-10-05T00:00:00.0000000' AS DateTime2), 4, N'laptop microsoft surface pro', N'mario bianchi', CAST(1200.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (5, CAST(N'2021-07-11T00:00:00.0000000' AS DateTime2), 3, N'tampone rapido covid-19', N'gianni morandi', CAST(12.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (6, CAST(N'2021-03-11T00:00:00.0000000' AS DateTime2), 2, N'cena ristorante dei fiori madrid', N'luca orsetti', CAST(49.99 AS Decimal(18, 2)), 0)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (8, CAST(N'2021-04-18T00:00:00.0000000' AS DateTime2), 1, N'una notte b&b', N'roberta beretta', CAST(30.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (9, CAST(N'2021-02-21T00:00:00.0000000' AS DateTime2), 1, N'tre notti hotel cagliari', N'mario bianchi', CAST(400.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Spesa] ([Id], [Data], [CategoriaId], [Descrizione], [Utente], [Importo], [Approvato]) VALUES (10, CAST(N'2021-10-08T00:00:00.0000000' AS DateTime2), 3, N'tampone covid', N'arianna pino', CAST(15.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Spesa] OFF
GO
/****** Object:  Index [IX_Spesa_CategoriaId]    Script Date: 08/10/2021 14:52:51 ******/
CREATE NONCLUSTERED INDEX [IX_Spesa_CategoriaId] ON [dbo].[Spesa]
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Spesa]  WITH CHECK ADD  CONSTRAINT [FK_Spesa_Categoria_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Spesa] CHECK CONSTRAINT [FK_Spesa_Categoria_CategoriaId]
GO
ALTER TABLE [dbo].[Spesa]  WITH CHECK ADD  CONSTRAINT [CK_Spesa_Importo] CHECK  (([Importo]>=(0)))
GO
ALTER TABLE [dbo].[Spesa] CHECK CONSTRAINT [CK_Spesa_Importo]
GO
USE [master]
GO
ALTER DATABASE [GestioneSpese] SET  READ_WRITE 
GO
