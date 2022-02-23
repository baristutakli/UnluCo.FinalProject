

create trigger TR_CheckBeforeInsertNewColor 
on dbo.Colors
Instead of INSERT 
as
BEGIN
	DECLARE @name nvarchar(MAX);
	DECLARE @CreatedAt datetime;
	DECLARE @IsActive bit;
	DECLARE @IsTitleExist nvarchar(MAX);
	select @name = Name from inserted;
	select @CreatedAt =CreatedAt from inserted;
	select @IsActive = IsActive from inserted;

	select @IsTitleExist=Name from Colors where Name=@name;
	print @IsTitleExist;
	if(@IsTitleExist is null)
	BEGIN 
	Insert Into Colors (Name,CreatedAt,IsActive)
	Values (@name,@CreatedAt,@IsActive)
	END
END

--go
--Insert into Colors (Name,CreatedAt,IsActive)
--Values('White',GETDATE(),1)
--go