/****** Object:  Database [perfil]    Script Date: 29/11/2022 17:05:43 ******/
USE perfil;
/****** Object:  Table [dbo].[Eventos]    Script Date: 29/11/2022 17:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Evento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tema] [varchar](50) NOT NULL,
	[Local] [varchar](50) NOT NULL,
	[QtdPessoas] [int] NOT NULL,
	[DataEvento] [DATETIME],
	[ImagemURL] [varchar](50),
	[Telefone] [varchar](50),
	[Email] [varchar](50),

 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Lote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Preco] [decimal](8,2) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[DataInicio] [DATETIME],
	[DataFim] [DATETIME],
	[EventoId] [int] NOT NULL,

 CONSTRAINT [PK_Lote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Palestrante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[MiniCurriculo] [varchar](250) NOT NULL,
	[ImagemURL] [varchar](50) NOT NULL,
	[Telefone] [varchar](50),
	[Email] [varchar](50),

 CONSTRAINT [PK_Palestrante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RedeSocial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[URL] [varchar](100) NOT NULL,
	[EventoId] [int] NULL,
	[PalestranteId] [int] NULL,

 CONSTRAINT [PK_RedeSocial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Palestrante_Evento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventoId] [int] NOT NULL,
	[PalestranteId] [int] NOT NULL,

 CONSTRAINT [PK_Palestrante_Evento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Lote]  WITH CHECK ADD  CONSTRAINT [FK_Lote_Evento] FOREIGN KEY([EventoId])
REFERENCES [dbo].[Evento] ([Id])
GO
ALTER TABLE [dbo].[Lote] CHECK CONSTRAINT [FK_Lote_Evento]
GO

ALTER TABLE [dbo].[RedeSocial]  WITH CHECK ADD CONSTRAINT [FK_RedeSocial_Evento] FOREIGN KEY([EventoId])
REFERENCES [dbo].[Evento] ([Id])
GO
ALTER TABLE [dbo].[RedeSocial] CHECK CONSTRAINT [FK_RedeSocial_Evento]
GO
ALTER TABLE [dbo].[RedeSocial]  WITH CHECK ADD CONSTRAINT [FK_RedeSocial_Palestrante] FOREIGN KEY([PalestranteId])
REFERENCES [dbo].[Palestrante] ([Id])
GO
ALTER TABLE [dbo].[RedeSocial] CHECK CONSTRAINT [FK_RedeSocial_Palestrante]
GO

ALTER TABLE [dbo].[Palestrante_Evento]  WITH CHECK ADD  CONSTRAINT [FK_PalestranteEvento_Evento] FOREIGN KEY([EventoId])
REFERENCES [dbo].[Evento] ([Id])
GO
ALTER TABLE [dbo].[Palestrante_Evento] CHECK CONSTRAINT [FK_PalestranteEvento_Evento]
GO
ALTER TABLE [dbo].[Palestrante_Evento]  WITH CHECK ADD  CONSTRAINT [FK_PalestranteEvento_Palestrante] FOREIGN KEY([PalestranteId])
REFERENCES [dbo].[Palestrante] ([Id])
GO
ALTER TABLE [dbo].[Palestrante_Evento] CHECK CONSTRAINT [FK_PalestranteEvento_Palestrante]
GO

ALTER DATABASE [perfil] SET  READ_WRITE 
GO
