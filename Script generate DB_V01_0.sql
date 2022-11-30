/****** Object:  Database [perfil]    Script Date: 29/11/2022 17:05:43 ******/
USE perfil;
/****** Object:  Table [dbo].[Eventos]    Script Date: 29/11/2022 17:05:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[EventoId] [int] IDENTITY(1,1) NOT NULL,
	[Tema] [varchar](50) NOT NULL,
	[Local] [varchar](50) NOT NULL,
	[Lote] [varchar](50) NOT NULL,
	[QtdPessoas] [int] NOT NULL,
	[DataEvento] [DATETIME] NOT NULL,
	[ImagemURL] [varchar](50) NOT NULL,

 CONSTRAINT [PK_Eventos] PRIMARY KEY CLUSTERED 
(
	[EventoId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER DATABASE [perfil] SET  READ_WRITE 
GO
