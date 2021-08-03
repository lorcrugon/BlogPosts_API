USE [BlogPostsDb]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorenzo Cruz
-- Create date: 08/02/2021
-- Description:	Send an Email to the blog owner advising that a new post was added
-- =============================================
ALTER TRIGGER SendEmail_to_BlogOwner
   ON  [dbo].[BlogPosts]
   AFTER INSERT
AS 
BEGIN

DECLARE @query NVARCHAR(1000),
        @Title NVARCHAR(150), 
		@Body NVARCHAR(MAX), 
		@Email NVARCHAR(250),
		@BlogPostId int,
		@AuthorId int,
		@session_usr NVARCHAR(60) = SESSION_USER
	
	SET NOCOUNT ON;

    SELECT  @BlogPostId = I.BlogPostId,
	        @Title = I.Title, 
	        @Body = I.Body, 
			@Email = AU.[Email],
			@AuthorId = I.AuthorId
      FROM  Inserted I
	  INNER JOIN [dbo].[Authors] AU
	  ON AU.[AuthorId] = I.AuthorId

	  INSERT INTO [dbo].[BlogPosts_Audit] -- Auditing Table
	  (BlogPostId,  Title,  Body,  AuthorId,  Email,  session_usr,  CreatedAt) values
	  (@BlogPostId, @Title, @Body, @AuthorId, @Email, @session_usr, getdate())

	  set @query='msdb.dbo.sp_send_dbmail @profile_name=''Notifications'',@recipients=''' + @Email + 
	             ''',@subject=''' + @Title + 
				 ''',@body=''' + @Body + 
				 ''''
       
    EXEC @query

END
GO


