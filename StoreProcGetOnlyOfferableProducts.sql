
alter proc SP_GetOnlyOfferableProducts
as
begin 
	
	select p.Id,p.Name, p.Description, p.Price, c.Name, b.Name, ct.Title,u.UserName from Products as p
	join Colors c on c.Id=p.ColorId
	join Brands b on b.Id=p.BrandId
	join Categories ct on p.CategoryId =ct.Id
	join AspNetUsers u on  u.Id=p.UserId
	where p.IsSold = 0  AND p.IsOfferable=1 AND p.IsActive=1

end


--exec SP_GetOnlyOfferableProducts

