USE [Epam11]
GO
/****** Object:  Table [dbo].[AwardUser]    Script Date: 19.02.2020 2:00:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardUser](
	[Id] [int] NOT NULL,
	[Id_Award] [int] NOT NULL,
	[Id_User] [int] NOT NULL,
 CONSTRAINT [PK_AwardUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AwardUser]  WITH CHECK ADD  CONSTRAINT [FK_AwardUser_Award] FOREIGN KEY([Id_Award])
REFERENCES [dbo].[Award] ([Id])
GO
ALTER TABLE [dbo].[AwardUser] CHECK CONSTRAINT [FK_AwardUser_Award]
GO
ALTER TABLE [dbo].[AwardUser]  WITH CHECK ADD  CONSTRAINT [FK_AwardUser_User] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[AwardUser] CHECK CONSTRAINT [FK_AwardUser_User]
GO
