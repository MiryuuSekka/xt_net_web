USE [Epam11]
GO
/****** Object:  Table [dbo].[WebUser]    Script Date: 19.02.2020 2:00:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebUser](
	[Id] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[id_Role] [int] NOT NULL,
 CONSTRAINT [PK_WebUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WebUser]  WITH CHECK ADD  CONSTRAINT [FK_WebUser_Role] FOREIGN KEY([id_Role])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[WebUser] CHECK CONSTRAINT [FK_WebUser_Role]
GO
