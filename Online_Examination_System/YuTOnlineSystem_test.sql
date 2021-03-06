USE [YuTOnlineSystem]
GO
/****** Object:  StoredProcedure [dbo].[spAdminRegisterinsert]    Script Date: 09.06.2020 14:23:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAdminRegisterinsert]
@admin_name nvarchar(500),

@password  nvarchar(50),
@email nvarchar(50)
as
begin
      declare @count int
	  declare @returnvalue int
	  select @count = COUNT(admin_email) from admin where admin_email=@email
	      if @count>0
		      begin
			     set @returnvalue = -1
				 end
				 
				 
			else
			  begin
			     set @returnvalue = 1
				 insert into admin(admin_name,admin_email,admin_password) values
				 (@admin_name,@email,@password)
				 end
		select @returnvalue as returnvalue
end