USE [BlogPostsDb]
GO

/****** Object:  Table [dbo].[Authors]    Script Date: 8/2/2021 4:04:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[Email] [nvarchar](250) NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
))
GO


