

create trigger TR_CheckBeforeInsertANewBrand 
on dbo.Brands
Instead of INSERT 
as
BEGIN
	DECLARE @name nvarchar(MAX);
	DECLARE @CreatedAt datetime;
	DECLARE @IsActive bit;
	DECLARE @IsNameExist nvarchar(MAX);
	select @name = Name from inserted;
	select @CreatedAt =CreatedAt from inserted;
	select @IsActive = IsActive from inserted;

	select @IsNameExist=Name from Brands where Name=@name;
	print @IsNameExist;
	if(@IsNameExist is null)
	BEGIN 
	Insert Into Brands (Name,CreatedAt,IsActive)
	Values (@name,@CreatedAt,@IsActive)
	END
END

--go
--Insert into Brands (Name,CreatedAt,IsActive)
--Values('BMW',GETDATE(),1)
--go