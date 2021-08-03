
-- To enable Database Mail, run the following code:
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
 
-- This is going to happen from time to time because this is an advanced option. To fix this, we need to change the show advanced options default value from 0 to 1.
-- To do this run the following code:
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
 
sp_configure 'Database Mail XPs', 1;
GO
RECONFIGURE
GO

-- To create a new Database Mail profile named ‘Notifications’ we will use the sysmail_add_profile_sp stored procedure and the following code:
-- Create a Database Mail profile  
EXECUTE msdb.dbo.sysmail_add_profile_sp  
    @profile_name = 'Notifications',  
    @description = 'Profile used for sending outgoing notifications using Gmail.' ;  
GO

-- To grant permission for a database user or role to use this Database Mail profile, we will use the sysmail_add_principalprofile_sp stored procedure and the following code:	
-- Grant access to the profile to the DBMailUsers role  
EXECUTE msdb.dbo.sysmail_add_principalprofile_sp  
    @profile_name = 'Notifications',  
    @principal_name = 'public',  
    @is_default = 1 ;
GO


-- To create a new Database Mail account holding information about an SMTP account, we will use the sysmail_add_account_sp stored procedure and the following code:
-- Create a Database Mail account  
EXECUTE msdb.dbo.sysmail_add_account_sp  
    @account_name = 'Gmail',  
    @description = 'Mail account for sending outgoing notifications.',  
    @email_address = 'lcruz@cavanny.com',  
    @display_name = 'Automated Mailer',  
    @mailserver_name = 'smtp.gmail.com',
    @port = 587,
    @enable_ssl = 1,
    @username = 'lcruz@cavanny.com',
    @password = 'DutyFree123' ;  
GO

-- To add the Database Mail account to the Database Mail profile, we will use the sysmail_add_profileaccount_sp stored procedure and the following code:
-- Add the account to the profile  
EXECUTE msdb.dbo.sysmail_add_profileaccount_sp  
    @profile_name = 'Notifications',  
    @account_name = 'Gmail',  
    @sequence_number =1 ;  
GO

-- Test
EXEC msdb.dbo.sp_send_dbmail
     @profile_name = 'Notifications',
     @recipients = 'lcgusa64@gmail.com',
     @body = 'The database mail configuration was completed successfully.',
     @subject = 'Automated Success Message';
GO

--Troubleshooting Database Mail
--In this case, the e-mail message was successfully queued, but the message was not delivered.
--First things first, check if Database Mail is enabled by executing the following code:

sp_configure 'show advanced', 1; 
GO
RECONFIGURE;
GO
sp_configure;
GO

-- To view the error messages returned by Database Mail, execute the following code:
SELECT * FROM msdb.dbo.sysmail_event_log;

--EXECUTE msdb.dbo.sysmail_delete_profileaccount_sp @profile_name = 'Notifications'
--EXECUTE msdb.dbo.sysmail_delete_principalprofile_sp @profile_name = 'Notifications'
--EXECUTE msdb.dbo.sysmail_delete_account_sp @account_name = 'Gmail'
--EXECUTE msdb.dbo.sysmail_delete_profile_sp @profile_name = 'Notifications'