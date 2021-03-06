USE [master]
GO
/****** Object:  Database [Empleados]    Script Date: 28/10/2021 19:39:35 ******/
CREATE DATABASE [Empleados]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Empleados', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQL\MSSQL\DATA\Empleados.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Empleados_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQL\MSSQL\DATA\Empleados_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Empleados] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Empleados].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Empleados] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Empleados] SET ARITHABORT OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Empleados] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Empleados] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Empleados] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Empleados] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Empleados] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Empleados] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Empleados] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Empleados] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Empleados] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Empleados] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Empleados] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Empleados] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Empleados] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Empleados] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Empleados] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Empleados] SET  MULTI_USER 
GO
ALTER DATABASE [Empleados] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Empleados] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Empleados] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Empleados] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Empleados] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Empleados', N'ON'
GO
USE [Empleados]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 28/10/2021 19:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[NombreArea] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 28/10/2021 19:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[IdDocumento] [int] NULL,
	[NumeroDocumento] [varchar](100) NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[IdArea] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubArea]    Script Date: 28/10/2021 19:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubArea](
	[IdSubArea] [int] IDENTITY(1,1) NOT NULL,
	[IdArea] [int] NULL,
	[NombreSubArea] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSubArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 28/10/2021 19:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[IdDocumento] [int] IDENTITY(1,1) NOT NULL,
	[NombreDocumento] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/10/2021 19:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([IdArea], [NombreArea]) VALUES (1, N'INFORMATICA')
INSERT [dbo].[Area] ([IdArea], [NombreArea]) VALUES (2, N'SEGURIDAD')
INSERT [dbo].[Area] ([IdArea], [NombreArea]) VALUES (3, N'ORDENANZA')
INSERT [dbo].[Area] ([IdArea], [NombreArea]) VALUES (4, N'ADMINISTRATIVO')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (1, 1, N'123456', N'SERGIO', N'FLORES', 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (2, 1, N'223345', N'SAMUEL', N'LOPEZ', 2)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (3, 1, N'343533', N'DENNIS', N'HUEZO', 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (5, NULL, N'2323432', N'JUAN', N'GOMEZ', 2)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (6, NULL, N'23231231', N'MIGUEL', N'PEREZ', 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (7, NULL, N'342342', N'FRANSISCO', N'GUTIERREZ', 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (8, NULL, N'003234234', N'JAIME', N'RUIZ', 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (9, NULL, N'23423432', N'MARCOS', N'PEREZ', 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (10, NULL, N'55454553', N'ARMANDO', N'GOMEZ', 1)
INSERT [dbo].[Empleado] ([IdEmpleado], [IdDocumento], [NumeroDocumento], [Nombre], [Apellido], [IdArea]) VALUES (11, NULL, N'43421', N'ANA', N'HERNANDEZ', 1)
SET IDENTITY_INSERT [dbo].[Empleado] OFF
SET IDENTITY_INSERT [dbo].[SubArea] ON 

INSERT [dbo].[SubArea] ([IdSubArea], [IdArea], [NombreSubArea]) VALUES (1, 1, N'INFORMATICA SUB AREA')
INSERT [dbo].[SubArea] ([IdSubArea], [IdArea], [NombreSubArea]) VALUES (2, 2, N'SEGURIDAD SUB AREA')
INSERT [dbo].[SubArea] ([IdSubArea], [IdArea], [NombreSubArea]) VALUES (3, 3, N'ORDENANZA SUB AREA')
INSERT [dbo].[SubArea] ([IdSubArea], [IdArea], [NombreSubArea]) VALUES (6, 4, N'SECRETARIA')
SET IDENTITY_INSERT [dbo].[SubArea] OFF
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([IdDocumento], [NombreDocumento]) VALUES (1, N'DUI')
INSERT [dbo].[TipoDocumento] ([IdDocumento], [NombreDocumento]) VALUES (2, N'NIT')
INSERT [dbo].[TipoDocumento] ([IdDocumento], [NombreDocumento]) VALUES (3, N'PASAPORTE')
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Password]) VALUES (1, N'sergio@mail.com', N'1234')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[TipoDocumento] ([IdDocumento])
GO
ALTER TABLE [dbo].[SubArea]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [dbo].[Area] ([IdArea])
GO
USE [master]
GO
ALTER DATABASE [Empleados] SET  READ_WRITE 
GO
