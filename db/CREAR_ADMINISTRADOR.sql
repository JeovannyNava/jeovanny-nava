USE [Recetario]
GO

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[ConcurrencyStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnd]
           ,[LockoutEnabled]
           ,[AccessFailedCount])
     VALUES
           ('2933b0ad-1062-4983-b102-72ec14419bce'
           ,'prueba@gmail.com'
           ,'PRUEBA@GMAIL.COM'
           ,'prueba@gmail.com'
           ,'PRUEBA@GMAIL.COM'
           ,0
           ,'AQAAAAEAACcQAAAAEBSITYCWa6uCVbPO9e95apG3VDHYtAq+LQYS7jrPinPFVW/3KTEQTSh8iSqXmCvdAg=='
           ,'TWZKZVEUIBIWQ4RNG6OUONQDTBT4G5MS'
           ,'32faa718-76fe-469d-90c9-7ab39d2fa4a4'
           ,null
           ,0
           ,0
           ,null
           ,1
           ,0)
GO


