USE [Epam11]
GO
/****** Object:  Table [dbo].[ImageAward]    Script Date: 19.02.2020 2:00:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageAward](
	[Id] [int] NOT NULL,
	[Id_award] [int] NOT NULL,
	[Id_image] [int] NOT NULL,
 CONSTRAINT [PK_ImageAward] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
