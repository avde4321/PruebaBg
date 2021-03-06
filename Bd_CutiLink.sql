create database [CutLinks]

USE [CutLinks]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 14/10/2020 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[ciEstado] [varchar](3) NOT NULL,
	[Descripcion] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ciEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registros]    Script Date: 14/10/2020 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registros](
	[CiRegistros] [int] IDENTITY(1,1) NOT NULL,
	[UrlOriginal] [varchar](max) NULL,
	[UrlShortern] [varchar](100) NULL,
	[TokenUrl] [varchar](50) NOT NULL,
	[ContIngreso] [int] NULL,
	[FechaIngreso] [varchar](10) NULL,
	[Estado] [varchar](3) NULL,
 CONSTRAINT [PK__Registro__8BA83E4721F83DD7] PRIMARY KEY CLUSTERED 
(
	[TokenUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Estado] ([ciEstado], [Descripcion]) VALUES (N'A', N'Activo')
INSERT [dbo].[Estado] ([ciEstado], [Descripcion]) VALUES (N'I', N'Inactivo')
ALTER TABLE [dbo].[Registros]  WITH CHECK ADD  CONSTRAINT [FK__Registros__Estad__1273C1CD] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estado] ([ciEstado])
GO
ALTER TABLE [dbo].[Registros] CHECK CONSTRAINT [FK__Registros__Estad__1273C1CD]
GO
