USE [BlogPostsDb]
GO

/****** Object:  Table [dbo].[BlogPosts_Audit]    Script Date: 8/2/2021 5:00:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BlogPosts_Audit](
	[BlogPostId] [int] NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	session_usr NVARCHAR(60)
)  
GO


