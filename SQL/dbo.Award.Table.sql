USE [Epam11]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 19.02.2020 2:00:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[id_image] [int] NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_Image] FOREIGN KEY([id_image])
REFERENCES [dbo].[Image] ([Id])
GO
ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_Image]
GO
