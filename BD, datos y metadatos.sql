USE [master]
GO
/****** Object:  Database [oficios]    Script Date: 28/07/2019 03:18:34 p. m. ******/
CREATE DATABASE [oficios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'oficios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\oficios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'oficios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\oficios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[Dependencia]    Script Date: 28/07/2019 03:18:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dependencia](
	[id] [int] NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Dependencia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dependencia_oficio]    Script Date: 28/07/2019 03:18:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dependencia_oficio](
	[oficio_id] [varchar](15) NOT NULL,
	[dependencia_id] [int] NOT NULL,
 CONSTRAINT [PK_dependencia_oficio] PRIMARY KEY CLUSTERED 
(
	[oficio_id] ASC,
	[dependencia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 28/07/2019 03:18:35 p. m. ******/
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
/****** Object:  Table [dbo].[Oficio]    Script Date: 28/07/2019 03:18:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oficio](
	[id] [varchar](15) NOT NULL,
	[Asunto] [varchar](1500) NULL,
	[Fecha_envio] [date] NULL,
	[Fecha_recibido] [date] NULL,
	[id_tipo] [varchar](5) NOT NULL,
	[id_estado] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Oficio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 28/07/2019 03:18:35 p. m. ******/
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
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (1, N'Órgano Interno de Control')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (2, N'Secretaría del H. Ayuntamiento de Ahome')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (3, N'Dirección de la Unidad de Transparencia')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (4, N'Dirección de Informatica')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (5, N'Coordinación Municipal de Proteccfión Cívil')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (6, N'Instituto Municipal de Arte y Cultura de Ahome')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (7, N'Sistema DIF Ahome')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (8, N'Junta de Agua Potable y Alcantarillado del Municipio de Ahome')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (9, N'Sistema DIF Ahome')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (10, N'Dirección General de la Comisión Municipal de Desarrollo de Centros Poblados
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (11, N'Instituto Municipal de las Mujeres de Ahome
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (12, N'Instituto Municipal de Planeación de Ahome
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (13, N'Instituto para la Prevención de Adicciones del Municipio de Ahome
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (14, N'Dirección de Atención y Participación Ciudadana
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (15, N'Dirección de Inspección y Normatividad
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (16, N'Dirección de Asuntos Jurídicos
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (17, N'Dirección de Comunicación Social
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (18, N'Dirección de Desarrollo Social y Humano
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (19, N'Dirección de Servicios Públicos
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (20, N'Dirección de Salud Municipal
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (21, N'Dirección de Medio Ambiente y Desarrollo Urbano
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (22, N'Dirección de Educación
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (23, N'Dirección de Egresos
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (24, N'Dirección de Planeación e Innovación Gubernamental
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (25, N'Dirección de Administración
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (26, N'Dirección de Obras Públicas
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (27, N'Instituto Municipal de la Juventud de Ahome
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (28, N'Dirección General de Seguridad Pública y Tránsito Municipal
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (29, N'Dirección de Ingresos
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (30, N'Síndico Procurador
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (31, N'Secretaría de economía
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (32, N'Todos
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (33, N'Externo
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (34, N'Presidente Municipal
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (35, N'Despacho de Presidencia
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (36, N'Tesorería 
')
INSERT [dbo].[Dependencia] ([id], [Nombre]) VALUES (37, N'Director de Tránsito Municipal
')
INSERT [dbo].[Estado] ([id], [Nombre]) VALUES (N'1', N'Recibido en tiempo
')
INSERT [dbo].[Estado] ([id], [Nombre]) VALUES (N'2', N'Recibido fuera  de tiempo
')
INSERT [dbo].[Estado] ([id], [Nombre]) VALUES (N'3', N'Sin respuesta
')
INSERT [dbo].[Estado] ([id], [Nombre]) VALUES (N'4', N'Sin solución
')
INSERT [dbo].[Estado] ([id], [Nombre]) VALUES (N'5', N'Comunicado
')
INSERT [dbo].[Tipo] ([id], [Nombre]) VALUES (N'1', N'Invitación
')
INSERT [dbo].[Tipo] ([id], [Nombre]) VALUES (N'2', N'Solicitud de información
')
INSERT [dbo].[Tipo] ([id], [Nombre]) VALUES (N'3', N'Solicitud de reunión
')
INSERT [dbo].[Tipo] ([id], [Nombre]) VALUES (N'4', N'Administrativo
')
INSERT [dbo].[Tipo] ([id], [Nombre]) VALUES (N'5', N'Externos
')
INSERT [dbo].[Tipo] ([id], [Nombre]) VALUES (N'6', N'Solicitud de material
')
INSERT [dbo].[Tipo] ([id], [Nombre]) VALUES (N'7', N'Respuesta a oficio 
')
ALTER TABLE [dbo].[dependencia_oficio]  WITH CHECK ADD  CONSTRAINT [FK_dependencia_oficio_Dependencia] FOREIGN KEY([dependencia_id])
REFERENCES [dbo].[Dependencia] ([id])
GO
ALTER TABLE [dbo].[dependencia_oficio] CHECK CONSTRAINT [FK_dependencia_oficio_Dependencia]
GO
ALTER TABLE [dbo].[dependencia_oficio]  WITH CHECK ADD  CONSTRAINT [FK_dependencia_oficio_Oficio1] FOREIGN KEY([oficio_id])
REFERENCES [dbo].[Oficio] ([id])
GO
ALTER TABLE [dbo].[dependencia_oficio] CHECK CONSTRAINT [FK_dependencia_oficio_Oficio1]
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
