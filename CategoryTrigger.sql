
-- Trigger

alter trigger TR_CheckBeforeInsertNewCategory 
on dbo.Categories
Instead of INSERT 
as
BEGIN
	DECLARE @title nvarchar(MAX);
	DECLARE @CreatedAt datetime;
	DECLARE @IsActive bit;
	DECLARE @IsTitleExist nvarchar(MAX);
	select @title = title from inserted;
	select @CreatedAt =CreatedAt from inserted;
	select @IsActive = IsActive from inserted;

	select @IsTitleExist=Title from Categories where Title=@title;
	print @IsTitleExist;
	if(@IsTitleExist is null)
	BEGIN 
	Insert Into Categories (Title,CreatedAt,IsActive)
	Values (@title,@CreatedAt,@IsActive)
	END
END

--go
--Insert into Categories(Title,CreatedAt,IsActive)
--Values('Ayakkabý',GETDATE(),1)
--go