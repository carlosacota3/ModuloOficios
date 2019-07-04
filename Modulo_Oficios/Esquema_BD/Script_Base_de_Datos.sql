USE [master]
GO
/****** Object:  Database [oficios]    Script Date: 7/2/2019 3:17:45 AM ******/
CREATE DATABASE [oficios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'oficios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\oficios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'oficios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\oficios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [oficios] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [oficios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [oficios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [oficios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [oficios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [oficios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [oficios] SET ARITHABORT OFF 
GO
ALTER DATABASE [oficios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [oficios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [oficios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [oficios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [oficios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [oficios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [oficios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [oficios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [oficios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [oficios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [oficios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [oficios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [oficios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [oficios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [oficios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [oficios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [oficios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [oficios] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [oficios] SET  MULTI_USER 
GO
ALTER DATABASE [oficios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [oficios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [oficios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [oficios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [oficios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [oficios] SET QUERY_STORE = OFF
GO
USE [oficios]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [oficios]
GO
/****** Object:  Table [dbo].[Dependencia]    Script Date: 7/2/2019 3:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dependencia](
	[id] [varchar](5) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Dependencia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 7/2/2019 3:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[id] [varchar](5) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oficio]    Script Date: 7/2/2019 3:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oficio](
	[id] [varchar](7) NOT NULL,
	[Asunto] [varchar](150) NOT NULL,
	[Fecha_envio] [date] NOT NULL,
	[Fecha_recibido] [date] NOT NULL,
	[id_dependencia] [varchar](5) NOT NULL,
	[id_tipo] [varchar](5) NOT NULL,
	[id_estado] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Oficio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 7/2/2019 3:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[id] [varchar](5) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Oficio]  WITH CHECK ADD  CONSTRAINT [FK_Oficio_Dependencia] FOREIGN KEY([id_dependencia])
REFERENCES [dbo].[Dependencia] ([id])
GO
ALTER TABLE [dbo].[Oficio] CHECK CONSTRAINT [FK_Oficio_Dependencia]
GO
ALTER TABLE [dbo].[Oficio]  WITH CHECK ADD  CONSTRAINT [FK_Oficio_Estado] FOREIGN KEY([id_estado])
REFERENCES [dbo].[Estado] ([id])
GO
ALTER TABLE [dbo].[Oficio] CHECK CONSTRAINT [FK_Oficio_Estado]
GO
ALTER TABLE [dbo].[Oficio]  WITH CHECK ADD  CONSTRAINT [FK_Oficio_Tipo] FOREIGN KEY([id_tipo])
REFERENCES [dbo].[Tipo] ([id])
GO
ALTER TABLE [dbo].[Oficio] CHECK CONSTRAINT [FK_Oficio_Tipo]
GO
USE [master]
GO
ALTER DATABASE [oficios] SET  READ_WRITE 
GO
